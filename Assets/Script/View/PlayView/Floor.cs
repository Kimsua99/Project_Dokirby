using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    /// <summary>
    /// None : ���
    /// Mid1, 2 : �߾ӹٴ� �̹���
    /// </summary>
    public enum FloorIndex { 
        InValid = -1, 

        None = 0, // ��� 
        Mid1,  // �߾�
        Mid2,  // �߾�1
        Left,  // ���� => ���� �����ʿ� ���� => PatternReleaser
        Right, // ������ => ���� ���ʿ� ���� => PatternChecker

        Mid_RainyStart, // �߾� => PatternChecker
        Mid1_Rainy, // �߾� - �� ����
        Mid2_Rainy, // �߾� - �� ����
        Mid_RainyEnd,  // �߾� => PatternReleaser

        Count 
    }





    [Header("UI")]
    public GameObject[] FloorObj = new GameObject[(int)FloorIndex.Count];

    [Header("Variable")]
    private FloorIndex floorIndex = FloorIndex.InValid;

    public void Awake()
    {
        Init(FloorIndex.Mid1);
    }
    public void Init(FloorIndex floorIndex)
    {
        this.floorIndex = floorIndex;

        foreach (var obj in FloorObj)
            obj.SetActive(false);

        FloorObj[(int)this.floorIndex].SetActive(true);
    }
}
