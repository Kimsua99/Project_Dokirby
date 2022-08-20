using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 하위 변수는 뷰의 인덱스를 의미하기도 하지만, 뷰의 이름을 의미하기도 함.
/// 즉, [프리팹 이름 == View 열거형 상수 의 각 인덱스이름]
/// 단, InValid 및 Main 은 제외
/// </summary>
public enum View
{
    InValid = -1,
    //Main,     // 메인뷰는 비활성화되거나, 사라지지 않음

    tutorial,
    play,


    Count
}

public class UIViewManager : MonoBehaviour
{
    private static UIViewManager instance;
    public static UIViewManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    /// <summary>
    /// 각 생성된 뷰의 프리팹 원형 배열 과, 뷰가 만들어질 순서를 저장하는 viewStack
    /// 생성된 오브젝트는 SuibViews 오브젝트의 자식으로 들어갈 것
    /// </summary>
    public UIView LobbyView;
    public List<GameObject> SubViewList;

    private void Awake()
    {
        Instance = this;
    }

    public void GoView(View view, string initData, bool needImmediate = false, UnityAction closeAction = null)
    {
        ClearAllView();

        // 메인뷰가 0이기에, -1 가중치 세팅
        UIView subView = SubViewList[(int)view].GetComponent<UIView>();
        subView.Show(initData, needImmediate, closeAction);
    }
    public void GoMain()
    {
        ClearAllView();
    }
    public void ClearAllView()
    {
        UIView subView = null;
        foreach (var subViewObj in SubViewList)
        {
            if (subViewObj == null)
                continue;

            subView = subViewObj.GetComponent<UIView>();
            if (subView == null)
                continue;

            subView.close();
        }
    }
}
