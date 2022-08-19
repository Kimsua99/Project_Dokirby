using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JsonFx.Json;

public class TitleView : UIView
{
    public class ClassData
    {

    }


    [Header("UI")]
    public Text Title;
    public Text Version;

    [Header("Variable")]
    private string title;



    private void Awake()
    {
        initAction = Initialize;
    }


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
        title = "DoKirby";
    }
    // ui 갱신
    private void UpdateUI()
    {
        Title.text = title;
        Version.text = Application.version;
    }




    public void OnClickStartBtn()
    {
        UIViewManager.Instance.GoView(View.play, null);
    }
    public void OnClickExitBtn()
    {
        Application.Quit();
    }
    public void OnClickCreditBtn()
    {

    }
}
