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

        DS.Add("ㅋㅋㅋ 야 저기 약골 지나간다~");
        DS.Add("우씨.. 놀리지마!!");
        DS.Add("쟨 화내도 귀엽네 ㅋㅋ 너가 그러고도 요괴야?");
        DS.Add("ㅋㅋㅋ 약해 빠져가지구");
        DS.Add("우씨…");
        DS.Add("어떻게 하면 내 강함을 인정해 줄거야..?");
        DS.Add("음.. 염라대왕 집 창고에 숨겨져있는 감투를 가져오면 인정해 줄게");
        DS.Add("…");
        DS.Add("ㅋㅋㅋㅋ 야 말도 안..도…어ㅓ…어…어어..?");
        DS.Add("야! 어디가?!");
        DS.Add("(흥..! 내 강함을 입증해 보겠어!)");

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
