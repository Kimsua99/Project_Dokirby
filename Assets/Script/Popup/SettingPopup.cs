using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : UIPopup
{
    public int retryNum = 0;
    public void OnClickRetryBtn()
    {
        Loading.Instance.LoadScene("Lobby");
    }
    public void OnClickHomeBtn()
    {
        Loading.Instance.LoadScene("Title");
    }
}