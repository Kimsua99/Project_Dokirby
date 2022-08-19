using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : UIView
{
    [Header("Prefab")]
    public GameObject[] BackOri;      // 뒷배경 원본
    public GameObject ForeOri;      // 뒷배경 - 앞 원본
    public GameObject FloorOri;     // 바닥 원본

    public Transform[] BackForeCloneParentTrans;    // 두개 => 시작점 하나, 생성점 하나
    public Transform[] FloorCloneParentTrans;       // 8개 => 시작점 7개, 생성점 1개

    [Header("Variable")]
    private bool isGameEnd;
    private Queue<GameObject> BackCloneQueue = new Queue<GameObject>();
    private Queue<GameObject> ForeCloneQueue = new Queue<GameObject>();
    private Queue<GameObject> FloorCloneQueue = new Queue<GameObject>();

    [Header("Game Control")]
    public float GameSpeed = 1f;       // 게임 전체 속도 => 0일시 모든 오브젝트 정지 필요
                                        

    public int BackMaxCount = 3;        // 최대 몇개까지 뒷배경 생성 가능한가?
    public int ForeMaxCount = 3;
    public int FloorMaxCount = 8;

    private void OnEnable()
    {
        // 공용 매니저에 고지
        // 해당 매니저를 통해 데이터 공유
        GameMaster.Instance.GameSpeed = GameSpeed;




        // 맵 제작 시작 구간
        StopAllCoroutines();
        //StartCoroutine(CreateBack());
        //StartCoroutine(CreateFore());
        //StartCoroutine(CreateFloor());
    }
    

    private IEnumerator CreateBack()
    {
        // 두장 우선생성 필요
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
        // 두장 우선생성 필요
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
        // 우선 8칸 생성 필요
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
