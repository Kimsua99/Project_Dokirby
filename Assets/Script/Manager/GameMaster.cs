using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singletone<GameMaster>
{
    public static readonly float GameSpeedStop = 0f;
    public static readonly float GameSpeedSlow = 1f;
    public static readonly float GameSpeedNormal = 10f;

    public enum PatternMode : int { Normal = 0, Spring, Umbrella, Grass, Count }

    public bool isGameEnd = false;
    public float GameSpeed;         // 게임 스피드
    private PatternMode Pattern;    // 현재 발생할 패턴 종류

    public PatternMode PATTERN
    {
        get { return Pattern; }
        set { Pattern = value; }
    }

    public void ShufflePattern()
    {
        System.Random rand = new System.Random();
        int randValue = rand.Next((int)PatternMode.Spring, (int)PatternMode.Umbrella + 1);

        PATTERN = (PatternMode)randValue;
    }
}
