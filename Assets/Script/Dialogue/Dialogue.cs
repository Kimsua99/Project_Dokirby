using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public bool DialogueStart = false;
    public bool isDialogueEnd = false;

    public int DSCnt = 0;

    public Text text;
    public GameObject Title;
    public GameObject PersonLeft;
    public GameObject PersonRight;
    public GameObject CenterIMG;
    public GameObject SceneEffect;

    public List<string> DS;
    public List<Sprite> Actor;
    public List<Sprite> LeftSprite;
    public List<Sprite> RightSprite;

    public Sprite KirbyName;
    public Sprite MonsterName;

    public Sprite Alpa;
    public Sprite Kirby1;
    public Sprite Kirby2;
    public Sprite Monster1;
    public Sprite Monster2;
    public Sprite Monster3;

    public Sprite Scene1;
    public Sprite Scene2;

    public GameObject FadePanel;

    public bool KSpeak = false;
    public bool MSpeak = false;

    private void Start()
    {
        DS = new List<string>();

        DS.Add("������ �� ���� ��� ��������~");
        DS.Add("�쾾.. �����!!");
        DS.Add("�� ȭ���� �Ϳ��� ���� �ʰ� �׷��� �䱫��?");
        DS.Add("������ ���� ����������");
        DS.Add("�쾾��");
        DS.Add("��� �ϸ� �� ������ ������ �ٰž�..?");
        DS.Add("��.. ������ �� â�� �������ִ� ������ �������� \n ������ �ٰ�");
        DS.Add("��");
        DS.Add("�������� �� ���� ��..������á�����..?");
        DS.Add("��! ���?!");
        DS.Add("(��..! �� ������ ������ ���ھ�!)");
        DS.Add("");

        Actor.Add(MonsterName);
        Actor.Add(KirbyName);
        Actor.Add(MonsterName);
        Actor.Add(MonsterName);
        Actor.Add(KirbyName);
        Actor.Add(KirbyName);
        Actor.Add(MonsterName);
        Actor.Add(KirbyName);
        Actor.Add(MonsterName);
        Actor.Add(MonsterName);
        Actor.Add(KirbyName);
        Actor.Add(KirbyName);

        LeftSprite.Add(Alpa);
        LeftSprite.Add(Kirby2);
        LeftSprite.Add(Alpa);
        LeftSprite.Add(Alpa);
        LeftSprite.Add(Kirby2);
        LeftSprite.Add(Kirby1);
        LeftSprite.Add(Alpa);
        LeftSprite.Add(Kirby1);
        LeftSprite.Add(Alpa);
        LeftSprite.Add(Alpa);
        LeftSprite.Add(Kirby1);
        LeftSprite.Add(Alpa);


        RightSprite.Add(Monster2);
        RightSprite.Add(Alpa);
        RightSprite.Add(Monster2);
        RightSprite.Add(Monster1);
        RightSprite.Add(Alpa);
        RightSprite.Add(Alpa);
        RightSprite.Add(Monster1);
        RightSprite.Add(Alpa);
        RightSprite.Add(Monster2);
        RightSprite.Add(Monster3);
        RightSprite.Add(Alpa);
        RightSprite.Add(Alpa);

        NextDialogue();
    }
    public void Update()
    {
        if (Title.GetComponent<Image>().sprite == KirbyName)
        {
            KSpeak = true;
            MSpeak = false;
        }
        if (Title.GetComponent<Image>().sprite == MonsterName)
        {
            KSpeak = false;
            MSpeak = true;
        }
    }
    public void NextDialogue()
    {
        DialogueStart = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Click");

        if (DSCnt == 0)
        {
            StopAll();

            StartCoroutine(NormalChat(DS[DSCnt]));
            SetImage(DSCnt);

            DSCnt++;
        }

        else if (DSCnt >= 1)
        {

            if (isDialogueEnd == true)
            {
                StopAll();

                StartCoroutine(NormalChat(DS[DSCnt]));
                SetImage(DSCnt);

                DSCnt++;

                if (DSCnt == 7)
                {
                    SceneEffect.SetActive(true);
                    CenterIMG.GetComponent<Image>().sprite = Scene1;
                    CenterIMG.GetComponent<Image>().SetNativeSize();

                }
                if (DSCnt == 8 || DSCnt == 9)
                {
                    SceneEffect.SetActive(false);
                    CenterIMG.GetComponent<Image>().sprite = Alpa;

                }
                if (DSCnt == 11)
                {
                    SceneEffect.SetActive(true);
                    CenterIMG.GetComponent<Image>().sprite = Scene2;
                    CenterIMG.GetComponent<Image>().SetNativeSize();
                }
                if (DSCnt == 12)
                {
                    Loading.Instance.LoadScene("Lobby");
                    //GameObject.Find("DialogueView").SetActive(false);
                }
            }
        }
    }
    IEnumerator NormalChat(string narration)// 
    {
        string writerText = "";
        if (DSCnt == 0)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 1)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");
        if (DSCnt == 2)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 3)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 4)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");
        if (DSCnt == 5)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");
        if (DSCnt == 6)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 7)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");
        if (DSCnt == 8)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 9)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("GType");
        if (DSCnt == 10)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");
        if (DSCnt == 11)
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("KType");




        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
                isDialogueEnd = true;
            else
                isDialogueEnd = false;
            text.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    public void SetImage(int Cnt)
    {
        Title.GetComponent<Image>().sprite = Actor[Cnt];
        Title.GetComponent<Image>().SetNativeSize();
        PersonLeft.GetComponent<Image>().sprite = LeftSprite[Cnt];
        PersonLeft.GetComponent<Image>().SetNativeSize();
        PersonRight.GetComponent<Image>().sprite = RightSprite[Cnt];
        PersonRight.GetComponent<Image>().SetNativeSize();
    }
    public void StopAll()
    {
        StopAllCoroutines();
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    public void Skip()
    {
        GameObject.Find("Skip").gameObject.SetActive(false);
        GameObject.Find("DialogueView").gameObject.SetActive(false);
        GameObject.Find("SubViews").transform.GetChild(0).gameObject.SetActive(true);
    }
}
