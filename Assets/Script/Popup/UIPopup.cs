using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPopup : MonoBehaviour
{
    public class PopupData
    {
        public View view = View.InValid;
        public string data = "";
        public bool immediatelyShow = false;

        public PopupData(View view, string data)
        {
            this.view = view;
            this.data = data;
            this.immediatelyShow = false;
        }
    }

    /// <summary>
    /// 각 Monobehavior 객체의 Awake 이벤트에서 초기화 시킬 것
    /// </summary>
    [HideInInspector]
    public UnityAction<string> initAction;
    [HideInInspector]
    public UnityAction closeAction;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    public void Show(string data, bool doImmediate = false, UnityAction closeAction = null)
    {
        this.closeAction = closeAction;

        this.gameObject.SetActive(true);

        if (doImmediate)
            canvasGroup.alpha = 1f;
        else
            Fade(true);

        initAction?.Invoke(data);
    }
    public void close(bool doImmediate = false)
    {
        if (doImmediate)
        {
            closeAction?.Invoke();
            this.gameObject.SetActive(false);
            return;
        }

        // close 호출시 이미 비활성화 된 상태면 해당 코루틴 비호출 시키기 위함
        if (this.gameObject.activeSelf)
            StartCoroutine(Fade(false));
    }


    /// <summary>
    /// 페이드 인아웃 코루틴
    /// </summary>
    /// <param name="isFadeIn"></param>
    /// <returns></returns>
    private IEnumerator Fade(bool isFadeIn)
    {
        const float maxTime = 1.5f;
        float timeAcc = 0f;

        float start = isFadeIn ? 1f : 0f;
        float end = isFadeIn ? 0f : 1f;

        while (timeAcc > maxTime)
        {
            timeAcc += Time.unscaledDeltaTime;

            if (canvasGroup != null)
                canvasGroup.alpha = Mathf.Lerp(start, end, (timeAcc / maxTime));

            yield return null;
        }

        if (isFadeIn == false)
        {
            closeAction?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
