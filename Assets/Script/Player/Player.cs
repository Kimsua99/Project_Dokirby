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

    [Header("UI")]
    public Image PlayerImg;
    public Rigidbody2D rigidBody;
    public Animator CharmAnimator;

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

        WalkAnim();
    }

    private void WalkAnim()
    {
        if (isLanding)
            return;

        accTimeDelta += Time.deltaTime;
        if (accTimeDelta >= 1 / GameMaster.Instance.GameSpeed)
        {
            PlayerImg.sprite = PlayerAnim_Run[curIndex];
            if (curIndex >= PlayerAnim_Run.Length - 1)
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
            mode = GameMaster.PatternMode.Normal;
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
                    GameMaster.Instance.GameSpeed = GameMaster.GameSpeedStop;
                    GameMaster.Instance.isGameEnd = true;

                    UIPopupManager.Instance.Show(Popup.Setting);
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

    private void ActivatePattern(string pattern)
    {
        if (GameMaster.Instance.isGameEnd)
            return;

        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Spring && pattern == "spring")
        {
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
            rigidBody.AddForce(Vector2.up * 300f);
            mode = GameMaster.PatternMode.Normal;
        }
        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Umbrella && pattern == "Umbrella")
        {
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
            mode = GameMaster.PatternMode.Umbrella;
        }

        GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;
        CharmAnimator.Play("MoveRight");

        Invoke(nameof(ShufflePattern), 5f);
    }
    private void ShufflePattern()
    {
        GameMaster.Instance.ShufflePattern();
    }
}
