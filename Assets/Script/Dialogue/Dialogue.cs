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

    private void Start()
    {
        DS = new List<string>();

        DS.Add("せせせ 醤 煽奄 鉦茨 走蟹娃陥~");
        DS.Add("酔松.. 且軒走原!!");
        DS.Add("潜 鉢鎧亀 瑛娠革 せせ 格亜 益君壱亀 推雨醤?");
        DS.Add("せせせ 鉦背 匙閃亜走姥");
        DS.Add("酔松・");
        DS.Add("嬢胸惟 馬檎 鎧 悪敗聖 昔舛背 匝暗醤..?");
        DS.Add("製.. 唇虞企腎 増 但壱拭 需移閃赤澗 姶燈研 亜閃神檎 \n 昔舛背 匝惟");
        DS.Add("・");
        DS.Add("せせせせ 醤 源亀 照..亀・嬢っ・嬢・嬢嬢..?");
        DS.Add("醤! 嬢巨亜?!");
        DS.Add("(被..! 鎧 悪敗聖 脊装背 左畏嬢!)");

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

    }
    public void NextDialogue()
    {
        DialogueStart = true;

        StopAll();

        StartCoroutine(NormalChat(DS[DSCnt]));
        SetImage(DSCnt);

        DSCnt++;
        if (DSCnt == 11)
        {
            GameObject.Find("DialogPopup").SetActive(false);
        }
    }
    IEnumerator NormalChat(string narration)// 
    {
        string writerText = "";
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
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
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
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
}
