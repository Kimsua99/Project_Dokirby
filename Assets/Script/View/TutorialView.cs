using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JsonFx.Json;

public class TutorialView : UIView
{
    public class ClassData
    {

    }

    private void Awake()
    {
        initAction = Initialize;
    }



    [Header("UI")]
    public GameObject[] Tutos;

    [Header("Variable")]
    private int curPopupIdx = 0;






    // 초기화
    private void Initialize(string data)
    {
        if (data != null)
        {
            ClassData classData = JsonReader.Deserialize<ClassData>(data);
            if (classData == null)
                return;
        }

        UpdateAll();
    }
    private void UpdateAll()
    {
        UpdateData();
        UpdateUI();
    }
    // 데이터 갱신
    private void UpdateData()
    {

    }
    // ui 갱신
    private void UpdateUI()
    {
        foreach (var Obj in Tutos)
            Obj.SetActive(false);

        Tutos[curPopupIdx].SetActive(true);
    }



    public void OnClickNextBtn()
    {
        curPopupIdx++;
        UpdateAll();
    }
    public void OnClickPrevBtn()
    {
        curPopupIdx--;
        UpdateAll();
    }

    public void OnClickSkipBtn()
    {
        UIViewManager.Instance.GoView(View.play, null);
    }
    public void OnClickStartBtn()
    {
        Loading.Instance.LoadScene("Lobby");
    }
}
