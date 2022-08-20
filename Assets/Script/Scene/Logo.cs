using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Logo : MonoBehaviour
{
    [Header("UI")]
    public CanvasGroup LogosRootObj;

    [Header("Variable")]
    private List<GameObject> LogoList = new List<GameObject>();
    private float fadeTime = 1f;
    private float delayTimeInLogoAnim = 1.5f;

    public void OnEnable()
    {
        // 1, ������Ʈ ���� => ��Ʈ ������Ʈ�� �ڽ� ������Ʈ���� ������ �ʱ�ȭ
        if (LogoList.Count > 0)
            LogoList.Clear();

        if (LogosRootObj == null)
            Application.Quit();

        GameObject gameObject = null;
        for (int i = 0; i < LogosRootObj.transform.childCount; i++)
        {
            gameObject = LogosRootObj.transform.GetChild(i).gameObject;
            gameObject.SetActive(false);
            LogoList.Add(gameObject);
        }

        // 2. �ΰ�� �ڷ�ƾ ����
        StartCoroutine("LogoAnimate");
    }
    IEnumerator LogoAnimate()
    {
        float start = 0f;
        float end = 1f;
        float accTime = 0f;

        WaitForSeconds delayTimeSecInLogoAnim = new WaitForSeconds(delayTimeInLogoAnim);

        foreach (var logo in LogoList)
        {
            start = 0f;
            end = 1f;

            LogosRootObj.alpha = 0f;
            logo.SetActive(true);

            accTime = 0f;
            while (LogosRootObj.alpha < 1f)
            {
                accTime += Time.deltaTime / fadeTime;
                LogosRootObj.alpha = Mathf.Lerp(start, end, accTime);
                yield return null;
            }

            yield return delayTimeSecInLogoAnim;

            start = 1f;
            end = 0f;

            accTime = 0f;
            while (LogosRootObj.alpha > 0f)
            {
                accTime += Time.deltaTime / fadeTime;
                LogosRootObj.alpha = Mathf.Lerp(start, end, accTime);
                yield return null;
            }

            logo.SetActive(false);
            LogosRootObj.alpha = 0f;
        }

        OnClickMoveToLoadingScene();
        yield return null;
    }
    public void OnClickMoveToLoadingScene()
    {
        StopAllCoroutines();
        Loading.Instance.LoadScene(Headers.SCENE_NAME_Title);
    }
}
