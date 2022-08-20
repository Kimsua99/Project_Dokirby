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
    public enum FloorIndex { 
        InValid = -1, 

        None = 0, // Çã°ø 
        Mid1,  // Áß¾Ó
        Mid2,  // Áß¾Ó1
        Left,  // ¿ÞÂÊ => Àýº® ¿À¸¥ÂÊ¿¡ »ý¼º => PatternReleaser
        Right, // ¿À¸¥ÂÊ => Àýº® ¿ÞÂÊ¿¡ »ý¼º => PatternChecker

        Mid_RainyStart, // Áß¾Ó => PatternChecker
        Mid1_Rainy, // Áß¾Ó - ºñ ¿µ¿ª
        Mid2_Rainy, // Áß¾Ó - ºñ ¿µ¿ª
        Mid_RainyEnd,  // Áß¾Ó => PatternReleaser

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
