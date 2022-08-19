using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public List<string> DS;
    public List<Sprite> Actor;
    public List<Sprite> LeftSprite;
    public List<Sprite> RightSprite;

    public Sprite KirbyName;
    public Sprite MonsterName;

    public Sprite Kirby1;
    public Sprite Kirby2;
    public Sprite Monster1;
    public Sprite Monster2;
    public Sprite Monster3;

    public void Start()
    {
        DS = new List<string>();

        DS.Add("せせせ 醤 煽奄 鉦茨 走蟹娃陥~");
        DS.Add("酔松.. 且軒走原!!");
        DS.Add("潜 鉢鎧亀 瑛娠革 せせ 格亜 益君壱亀 推雨醤?");
        DS.Add("せせせ 鉦背 匙閃亜走姥");
        DS.Add("酔松・");
        DS.Add("嬢胸惟 馬檎 鎧 悪敗聖 昔舛背 匝暗醤..?");
        DS.Add("製.. 唇虞企腎 増 但壱拭 需移閃赤澗 姶燈研 亜閃神檎 昔舛背 匝惟");
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

        LeftSprite.Add(null);
        LeftSprite.Add(Kirby2);
        LeftSprite.Add(null);
        LeftSprite.Add(null);
        LeftSprite.Add(Kirby2);
        LeftSprite.Add(Kirby1);
        LeftSprite.Add(null);
        LeftSprite.Add(Kirby1);
        LeftSprite.Add(null);
        LeftSprite.Add(null);
        LeftSprite.Add(Kirby1);

        RightSprite.Add(Monster2);
        RightSprite.Add(null);
        RightSprite.Add(Monster2);
        RightSprite.Add(Monster1);
        RightSprite.Add(null);
        RightSprite.Add(null);
        RightSprite.Add(Monster1);
        RightSprite.Add(null);
        RightSprite.Add(Monster2);
        RightSprite.Add(Monster3);
        RightSprite.Add(null);




    }
}
