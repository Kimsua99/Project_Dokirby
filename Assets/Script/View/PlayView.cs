using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : UIView
{
    [Header("Prefab")]
    public GameObject[] BackOri;      // �޹�� ����
    public GameObject ForeOri;      // �޹�� - �� ����
    public GameObject FloorOri;     // �ٴ� ����

    public Transform[] BackForeCloneParentTrans;    // �ΰ� => ������ �ϳ�, ������ �ϳ�
    public Transform[] FloorCloneParentTrans;       // 8�� => ������ 7��, ������ 1��

    [Header("Variable")]
    private bool isGameEnd;
    private Queue<GameObject> BackCloneQueue = new Queue<GameObject>();
    private Queue<GameObject> ForeCloneQueue = new Queue<GameObject>();
    private Queue<GameObject> FloorCloneQueue = new Queue<GameObject>();

    [Header("Game Control")]
    public float GameSpeed = 1f;       // ���� ��ü �ӵ� => 0�Ͻ� ��� ������Ʈ ���� �ʿ�
                                        

    public int BackMaxCount = 3;        // �ִ� ����� �޹�� ���� �����Ѱ�?
    public int ForeMaxCount = 3;
    public int FloorMaxCount = 8;

    private void OnEnable()
    {
        // ���� �Ŵ����� ����
        // �ش� �Ŵ����� ���� ������ ����
        GameMaster.Instance.GameSpeed = GameSpeed;




        // �� ���� ���� ����
        StopAllCoroutines();
        //StartCoroutine(CreateBack());
        //StartCoroutine(CreateFore());
        //StartCoroutine(CreateFloor());
    }
    

    private IEnumerator CreateBack()
    {
        // ���� �켱���� �ʿ�
        GameObject clonedBack = null;
        for(int i = 0; i < BackForeCloneParentTrans.Length - 1; i++)
        {
            clonedBack = Instantiate<GameObject>(GetRandomBackOri(), BackForeCloneParentTrans[i]);
            BackCloneQueue.Enqueue(clonedBack);
        }

        while (isGameEnd == false)
        {
            clonedBack = null;
            if (BackCloneQueue.Count > BackMaxCount)
            {
                clonedBack = BackCloneQueue.Dequeue();
                Destroy(clonedBack);
            }

            clonedBack = Instantiate<GameObject>(GetRandomBackOri(), BackForeCloneParentTrans[BackForeCloneParentTrans.Length - 1]);
            BackCloneQueue.Enqueue(clonedBack);
            yield return null;
        }
        yield break;
    }
    private IEnumerator CreateFore()
    {
        // ���� �켱���� �ʿ�
        GameObject clonedBack = null;
        for (int i = 0; i < BackForeCloneParentTrans.Length - 1; i++)
        {
            clonedBack = Instantiate<GameObject>(ForeOri, BackForeCloneParentTrans[i]);
            ForeCloneQueue.Enqueue(clonedBack);
        }

        while (isGameEnd == false)
        {
            clonedBack = null;
            if (ForeCloneQueue.Count > ForeMaxCount)
            {
                clonedBack = ForeCloneQueue.Dequeue();
                Destroy(clonedBack);
            }

            clonedBack = Instantiate<GameObject>(ForeOri, BackForeCloneParentTrans[BackForeCloneParentTrans.Length - 1]);
            ForeCloneQueue.Enqueue(clonedBack);
        }
        yield break;
    }
    private IEnumerator CreateFloor()
    {
        // �켱 8ĭ ���� �ʿ�
        GameObject clonedBack = null;
        for (int i = 0; i < BackForeCloneParentTrans.Length - 1; i++)
        {
            clonedBack = Instantiate<GameObject>(FloorOri, FloorCloneParentTrans[i]);
            FloorCloneQueue.Enqueue(clonedBack);
        }


        while (isGameEnd == false)
        {
            clonedBack = null;
            if (FloorCloneQueue.Count > FloorMaxCount)
            {
                clonedBack = FloorCloneQueue.Dequeue();
                Destroy(clonedBack);
            }

            clonedBack = Instantiate<GameObject>(FloorOri, FloorCloneParentTrans[FloorCloneParentTrans.Length - 1]);
            FloorCloneQueue.Enqueue(clonedBack);
        }
        yield break;
    }


    private GameObject GetRandomBackOri()
    {
        System.Random rand = new System.Random();


        int value = rand.Next(0, BackOri.Length);
        if (value < 0 || value >= BackOri.Length)
            return null;

        return BackOri[value];
    }
}
