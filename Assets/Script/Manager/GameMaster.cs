using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singletone<GameMaster>
{
    public static readonly float GameSpeedSlow = 1f;
    public static readonly float GameSpeedNormal = 10f;

    public enum PatternMode : int { Normal = 0, Spring, Grass, Umbrella, Count }

    public bool isGameEnd = false;
    public float GameSpeed;         // ���� ���ǵ�
    private PatternMode Pattern;    // ���� �߻��� ���� ����

    public PatternMode PATTERN
    {
        get { return Pattern; }
        set { Pattern = value; }
    }

    public void ShufflePattern()
    {
        System.Random rand = new System.Random();
        int randValue = (int)PatternMode.Spring;//rand.Next((int)PatternMode.Spring, (int)PatternMode.Count);

        PATTERN = (PatternMode)randValue;
    }
}
