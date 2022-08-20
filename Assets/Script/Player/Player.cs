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

    [Header("UI")]
    public Image PlayerImg;
    public Rigidbody2D rigidBody;
    public Animator CharmAnimator;

    [Header("Variable")]
    private GameMaster.PatternMode mode;


    private void Awake()
    {
        PatternTriggerAction = ActivatePattern;
    }
    private void Start()
    {
        Invoke(nameof(ShufflePattern), 5f);
    }

    private int curIndex = 0;
    private float accTimeDelta;
    public void Update()
    {
        WalkAnim();
    }

    private void WalkAnim()
    {
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
            // ���� ���
            CharmAnimator.Play("MoveLeft");

            // �̵��� ����
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedSlow;

            // ���� ����
            GameMaster.Instance.PATTERN = patternChecker.PatternMode;
        }


        PatternReleaser patternReleaser = collision.gameObject.GetComponent<PatternReleaser>();
        if(patternReleaser != null)
        {
            // �̵��� ����
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;

            // ���� ����
            GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;
        }      
    }



    private void ActivatePattern(string pattern)
    {
        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Spring && pattern == "spring")
        {
            GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
            rigidBody.AddForce(Vector2.up * 300f);
        }
        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Grass && pattern == "grass")
        {

        }
        if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Umbrella && pattern == "Umbrella")
        {

        }

        // ����
        GameMaster.Instance.PATTERN = GameMaster.PatternMode.Normal;
        CharmAnimator.Play("MoveRight");

        Invoke(nameof(ShufflePattern), 5f);
    }
    private void ShufflePattern()
    {
        GameMaster.Instance.ShufflePattern();
    }



}
