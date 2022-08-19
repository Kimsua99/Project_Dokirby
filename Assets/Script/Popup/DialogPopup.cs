using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopup : UIPopup
{
    [Header("UI")]
    public Text Desc;

    
    /// <summary>
    /// �̺�Ʈ �� �� ���� ��� ���,
    /// ��簡 �����ٸ� �ش� �˾� ���� �� �ΰ��� ����
    /// </summary>
    public void OnClickPassBtn()
    {
        bool isDescriptionEnd = false;

        if(isDescriptionEnd)
        {

            return;
        }

        StopAllCoroutines();
        StartCoroutine(FlowDialog()) ;     
    }

    /// <summary>
    /// �� ���ھ� ��� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    private IEnumerator FlowDialog()
    {
        Desc.text = "";





        yield break;
    }
}
