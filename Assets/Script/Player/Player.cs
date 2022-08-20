using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction<string> PatternTriggerAction;

    [Header("Resource")]
    public Sprite[] PlayerAnim_Run;
    public Sprite[] PlayerAnimLanding;
    public Sprite[] PlayerAnimSpring;
    public Sprite[] PlayerAnimUmbrella;
    public Sprite[] PlayerDeadByRaining;

    [Header("UI")]
    public Image PlayerImg;
    public Rigidbody2D rigidBody;
    public Animator CharmAnimator;
    public Animator PlayerUmbrellaSwayAnim;
    public Animator PlayerChangeExplodeEffect;

    [Header("Variable")]
    private GameMaster.PatternMode mode;
    private bool isLanding = false;


    private void Awake()
    {
        PatternTriggerAction = ActivatePattern;
    }
    private void Start()
    {

        StartCoroutine(SuperHeroLanding());
    }


    // 인게임 연출
    private IEnumerator SuperHeroLanding()
    {
        GameMaster.Instance.GameSpeed = 0f;
        isLanding = true;

        //FMODUnity.RuntimeManager.PlayOneShot();

        PlayerImg.sprite = PlayerAnimLanding[0];
        // Fall Down 2 sec
        yield return new WaitForSeconds(2f);
        PlayerChangeExplodeEffect.Play("Explode", -1, 0f);

        PlayerImg.sprite = PlayerAnimLanding[1];
        yield return new WaitForSeconds(0.25f);
        PlayerImg.sprite = PlayerAnimLanding[2];
        yield return new WaitForSeconds(0.25f);
        PlayerImg.sprite = PlayerAnimLanding[3];
        yield return new WaitForSeconds(0.25f);
        PlayerImg.sprite = PlayerAnimLanding[4];
        yield return new WaitForSeconds(0.25f);

        // Landing 3 secs
        //yield return new WaitForSeconds(1f);

        PlayerImg.sprite = PlayerAnimLanding[5];
        // Get Up 1 sec
        yield return new WaitForSeconds(2f);

        GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
        isLanding = false;
        Invoke(nameof(ShufflePattern), 5f);
    }










    // 본게임
    private int curIndex = 0;
    private float accTimeDelta;
    public void Update()
    {
        if (GameMaster.Instance.isGameEnd)
            return;

        Animinating();
    }
    private void Animinating()
    {
        if (isLanding)
            return;

        accTimeDelta += Time.deltaTime;


        Sprite[] sprites = null;
        switch (mode)
        {
            case GameMaster.PatternMode.Normal:
                sprites = PlayerAnim_Run;
                break;
            case GameMaster.PatternMode.Umbrella:
                sprites = PlayerAnimUmbrella;
                break;
            case GameMaster.PatternMode.Spring:
                sprites = PlayerAnimSpring;
                break;
        }


        if (accTimeDelta >= 1 / GameMaster.Instance.GameSpeed)
        {
            if (curIndex < 0 || curIndex >= sprites.Length)
                curIndex = 0;

            PlayerImg.sprite = sprites[curIndex];
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("Walk");
            if (curIndex >= sprites.Length - 1)
                curIndex = 0;
            else
                curIndex++;

            accTimeDelta = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;

        PatternChecker patternChecker = collision.gameObject.GetComponent<PatternChecker>();
        if (patternChecker != null)
        {
            // 부적 출력
            CharmAnimator.Play("MoveLeft");

            // 이동력 저하
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedSlow;

            // 패턴 세팅
            GameMaster.Instance.PATTERN = patternChecker.PatternMode;
        }

        PatternReleaser patternReleaser = collision.gameObject.GetComponent<PatternReleaser>();
        if (patternReleaser != null)
        {
            // 이동력 저하
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;

            // 패턴 세팅
            GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;

            // 플레이어 상태 전환
            if(mode != GameMaster.PatternMode.Spring)
                mode = GameMaster.PatternMode.Normal;

            if (mode == GameMaster.PatternMode.Normal)
            {
                PlayerUmbrellaSwayAnim.enabled = false;
                PlayerChangeExplodeEffect.Play("Explode", -1, 0f);
            }
        }

        DeadChecker deadChecker = collision.gameObject.GetComponent<DeadChecker>();
        if (deadChecker != null)
        {
            if(GameMaster.Instance.PATTERN == GameMaster.PatternMode.Umbrella)
            {
                if (mode == GameMaster.PatternMode.Umbrella)
                    return;
                else
                {
                    // 산성비 => 사망처리
                    //GameMaster.Instance.GameSpeed = GameMaster.GameSpeedStop;
                    GameMaster.Instance.GameSpeed = 2f;
                    GameMaster.Instance.isGameEnd = true;


                    StartCoroutine(DeadByRaining());


                }
            }
            if(GameMaster.Instance.PATTERN == GameMaster.PatternMode.Spring)
            {
                // 낙사 => 사망처리
                GameMaster.Instance.GameSpeed = GameMaster.GameSpeedStop;
                GameMaster.Instance.isGameEnd = true;

                UIPopupManager.Instance.Show(Popup.Setting);
            }
        }
    }
    // 바닥 착지용
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (mode == GameMaster.PatternMode.Spring)
        {
            rigidBody.AddForce(Vector2.up * 180f);
            mode = GameMaster.PatternMode.Normal;
            PlayerChangeExplodeEffect.Play("Explode", -1, 0f);
        }
    }


   
    private IEnumerator DeadByRaining()
    {
        yield return new WaitForSeconds(1.8f);
        
        int index = 0;
        int deadCount = PlayerDeadByRaining.Length;
        GameMaster.Instance.GameSpeed = 0f;

        while (index < deadCount)
        {
            PlayerImg.sprite = PlayerDeadByRaining[index];
            yield return new WaitForSeconds(0.1f);
            index++;
        }


        UIPopupManager.Instance.Show(Popup.Setting);
        yield break;
    }


    private void ActivatePattern(string pattern)
    {
        if (GameMaster.Instance.isGameEnd)
            return;

        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Spring && pattern == "spring")
        {
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
            rigidBody.AddForce(Vector2.up * 300f);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayPlus("Spring");
            PlayerChangeExplodeEffect.Play("Explode", -1, 0f);
            mode = GameMaster.PatternMode.Spring;
            CharmAnimator.Play("MoveRight");

            GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;
        }
        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Umbrella && pattern == "Umbrella")
        {
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
            mode = GameMaster.PatternMode.Umbrella;
            PlayerChangeExplodeEffect.Play("Explode", -1, 0f);
            PlayerUmbrellaSwayAnim.enabled = true;
            CharmAnimator.Play("MoveRight");

            GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;
        }

        Invoke(nameof(ShufflePattern), 5f);
    }
    private void ShufflePattern()
    {
        GameMaster.Instance.ShufflePattern();
    }
}
