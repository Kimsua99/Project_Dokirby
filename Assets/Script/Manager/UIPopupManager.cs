using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Popup
{
    InValid = -1,

    Setting = 0,


    Count
}

public class UIPopupManager : MonoBehaviour
{
    private static UIPopupManager instance;
    public static UIPopupManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [Header("UI")]
    public List<GameObject> SubPopupList;

    private void Awake()
    {
        Instance = this;
    }
    public void Show(Popup popup, string data = null, bool doImmediately = false, UnityAction closeAction = null)
    {
        ClearAllPopup();

        UIPopup uiPopup = SubPopupList[(int)popup].GetComponent<UIPopup>();
        if (uiPopup == null)
            return;

        uiPopup.Show(data, doImmediately, closeAction);
    }


    public void ClearAllPopup()
    {
        UIPopup uiPopup = null;
        foreach (var popupObj in SubPopupList)
        {
            uiPopup = popupObj.GetComponent<UIPopup>();
            if (uiPopup == null)
                continue;

            uiPopup.close();
        }
    }
}
