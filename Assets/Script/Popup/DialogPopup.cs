using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopup : UIPopup
{
    [Header("UI")]
    public Text Desc;

    
    /// <summary>
    /// 이벤트 콜 시 다음 대사 출력,
    /// 대사가 끝난다면 해당 팝업 삭제 및 인게임 시작
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
    /// 한 글자씩 출력 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator FlowDialog()
    {
        Desc.text = "";





        yield break;
    }
}
