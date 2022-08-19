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
    /// �̺�Ʈ �� �� ���� ��� ���,
    /// ��簡 �����ٸ� �ش� �˾� ���� �� �ΰ��� ����
    /// </summary>
    public void OnClickPassBtn()
    {
        StopAllCoroutines();

        if (chatMode == ChatMode.Chatting)
        {
            // ��� �ϼ�



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
                // �ѱ��ھ� Ÿ����
                
            }
            else if(chatMode == ChatMode.Complete)
            {
                // ȭ��ǥ Ȱ��ȭ


                yield break;
            }

            yield return null;
        }
    }
}
