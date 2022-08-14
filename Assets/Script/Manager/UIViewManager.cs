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
    public Transform SubViews;
    public UIView LobbyView;
    public List<UIView> SubViewList;

    private void Awake()
    {
        Instance = this;
    }

    public void GoView(View view, string initData, bool needImmediate = false, UnityAction closeAction = null)
    {
        foreach (var subView in SubViewList)
        {
            if (subView == null)
                continue;

            subView.close();
        }

        // ���κ䰡 0�̱⿡, -1 ����ġ ����
        UIView selView = SubViewList[(int)view];
        selView.Show(initData, needImmediate, closeAction);
    }
    public void GoMain()
    {
        foreach (var subView in SubViewList)
            subView.close();
    }
}
