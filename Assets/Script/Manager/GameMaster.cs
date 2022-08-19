using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singletone<GameMaster>
{
    public bool isGameEnd = false;
    public float GameSpeed = 10f;        // 게임 스피드
}
