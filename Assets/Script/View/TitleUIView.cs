using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JsonFx.Json;
using UnityEngine.SceneManagement;
public class TitleUIView : UIView
{
    public AudioClip StartBtn;
    public GameObject FadePannel;
    public class ClassData
    {

    }


    [Header("UI")]
    //public Text Title;
    //public Text Version;

    [Header("Variable")]
    private string title;



    private void Awake()
    {
        initAction = Initialize;
    }


    // ??????
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
    // ?????? ????
    private void UpdateData()
    {
        title = "DoKirby";
    }
    // ui ????
    private void UpdateUI()
    {
        //Title.text = title;
        //Version.text = Application.version;
    }




    public void OnClickStartBtn()
    {
        GameObject.Find("SFXManager").GetComponent<AudioSource>().Play();
        //UIViewManager.Instance.GoView(View.play, null);

        GameObject.Find("Panel").gameObject.SetActive(false);

        Invoke("SceneChange", 1f);
        StartCoroutine(FadeIn());

    }
    public void OnClickExitBtn()
    {
        Application.Quit();
    }
    public void OnClickCreditBtn()
    {

    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator FadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = new Color(0, 0, 0, 255);
            c.a = f;
            FadePannel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
