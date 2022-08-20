using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : UIView
{
    private void Awake()
    {
        initAction = Initialize;
    }
    private void Initialize(string data)
    {
        UpdateAll();
    }

    void Start()
    {

    }

    private void UpdateAll()
    {
        UpdateData();
        UpdateUI();
    }

    private void UpdateData()
    {
        GameMaster.Instance.GameSpeed = GameMaster.GameSpeedNormal;
    }
    private void UpdateUI()
    {

    }



}