using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    /// <summary>
    /// None : Çã°ø
    /// Mid1, 2 : Áß¾Ó¹Ù´Ú ÀÌ¹ÌÁö
    /// </summary>
    public enum FloorIndex { InValid = -1, None = 0, Mid1, Mid2, Left, Right, Count }

    [Header("UI")]
    public GameObject[] FloorObj = new GameObject[(int)FloorIndex.Count];

    [Header("Variable")]
    private FloorIndex floorIndex = FloorIndex.InValid;

    public void Awake()
    {
        Init(FloorIndex.Mid1);
    }
    public void Init(FloorIndex index)
    {
        floorIndex = index;
        foreach (var obj in FloorObj)
            obj.SetActive(false);

        FloorObj[(int)floorIndex].SetActive(true);
    }
}
