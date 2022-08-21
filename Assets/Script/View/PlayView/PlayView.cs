using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : UIView
{
    public Text SpeedTxt;

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



    private float timeAcc = 0f;

    private void Update()
    {
        timeAcc += Time.deltaTime;
        if(timeAcc >= 5f)
        {
            GameMaster.Instance.GameSpeedWeight += 0.01f;
            timeAcc = 0f;
        }

        SpeedTxt.text =  $"{GameMaster.Instance.GetGameSpeed()}m/sec";
    }




}