using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : UIPopup
{
    public void OnClickRetryBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Click");
        Loading.Instance.LoadScene("Lobby");
    }
    public void OnClickHomeBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Click");
        Loading.Instance.LoadScene("Title");
    }
}
