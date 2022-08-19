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

        DS.Add("������ �� ���� ��� ��������~");
        DS.Add("�쾾.. �����!!");
        DS.Add("�� ȭ���� �Ϳ��� ���� �ʰ� �׷��� �䱫��?");
        DS.Add("������ ���� ����������");
        DS.Add("�쾾��");
        DS.Add("��� �ϸ� �� ������ ������ �ٰž�..?");
        DS.Add("��.. ������ �� â�� �������ִ� ������ �������� ������ �ٰ�");
        DS.Add("��");
        DS.Add("�������� �� ���� ��..������á�����..?");
        DS.Add("��! ���?!");
        DS.Add("(��..! �� ������ ������ ���ھ�!)");

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
