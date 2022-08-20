using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ���� ������ ���� �ε����� �ǹ��ϱ⵵ ������, ���� �̸��� �ǹ��ϱ⵵ ��.
/// ��, [������ �̸� == View ������ ��� �� �� �ε����̸�]
/// ��, InValid �� Main �� ����
/// </summary>
public enum View
{
    InValid = -1,
    //Main,     // ���κ�� ��Ȱ��ȭ�ǰų�, ������� ����

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
    /// �� ������ ���� ������ ���� �迭 ��, �䰡 ������� ������ �����ϴ� viewStack
    /// ������ ������Ʈ�� SuibViews ������Ʈ�� �ڽ����� �� ��
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

        // ���κ䰡 0�̱⿡, -1 ����ġ ����
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
