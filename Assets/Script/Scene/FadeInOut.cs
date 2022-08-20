using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour
{
    public GameObject FadePannel;
    public IEnumerator FadeInStart()
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

    //페이드 인
    public IEnumerator FadeOutStart()
    {
        for (int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = new Color(0, 0, 0, 0);
            c.a = f;
            FadePannel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.1f);
        }
        FadePannel.SetActive(false);
    }
}
