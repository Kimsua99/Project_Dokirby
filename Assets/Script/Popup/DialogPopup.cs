using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopup : UIPopup
{
    public enum ChatMode { Start, Chatting, Complete };


    [Header("UI")]
    public Image LeftPerson;
    public Image RightPerson;
    public Image CenterPerson;
    public Text Name;
    public Text Desc;


    [Header("Variable")]
    private int talkTableIndex;
    private ChatMode chatMode;

    public void Start()
    {
        talkTableIndex = 1;
        chatMode = ChatMode.Start;

        StartCoroutine(DescChatting());
    }

    /// <summary>
    /// 이벤트 콜 시 다음 대사 출력,
    /// 대사가 끝난다면 해당 팝업 삭제 및 인게임 시작
    /// </summary>
    public void OnClickPassBtn()
    {
        StopAllCoroutines();

        if (chatMode == ChatMode.Chatting)
        {
            // 즉시 완성



            chatMode = ChatMode.Start;
            return;
        }
        else
            talkTableIndex++;

        StartCoroutine(DescChatting());
    }


    IEnumerator DescChatting()
    {
        TalkTable talkTable = TalkTable.GET($"Talk_{talkTableIndex}");
        if (talkTable == null)
            yield break;

        StringTable docStringTable = StringTable.GET(talkTable.StringID);
        if (docStringTable == null)
            yield break;

        //TutorialTable docTutoTable = ;

        while (true)
        {
            if (chatMode == ChatMode.Start)
                chatMode = ChatMode.Chatting;
            else if(chatMode == ChatMode.Chatting)
            {
                // 한글자씩 타이핑
                
            }
            else if(chatMode == ChatMode.Complete)
            {
                // 화살표 활성화


                yield break;
            }

            yield return null;
        }
    }
}
