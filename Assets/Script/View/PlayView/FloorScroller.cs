using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorScroller : MonoBehaviour
{
    public readonly int TrapGap = 4; // ¿À.¿Þ Àýº® + ºóÄ­
    public Transform[] floors;

    private float leftPosX = 0f;
    private float rightPosX = 0f;
    private float xScreenHalfSize;
    private float yScreenHalfSize;
    private int TrapGapAcc = 0;

    // Start is called before the first frame update
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize);
        rightPosX = xScreenHalfSize * 2;
    }




    private void Update()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].position += new Vector3(-GameMaster.Instance.GameSpeed, 0, 0) * Time.deltaTime;

            // º¯°æ ½ÃÁ¡
            if (floors[i].position.x + 1f < leftPosX) // ¿ùµå pos °ª,
            {
                Vector3 nextPos = floors[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX + 3f, nextPos.y, nextPos.z);
                floors[i].position = nextPos;

                Floor floor = floors[i].GetComponent<Floor>();
                if (floor == null)
                    continue;


                // ÆÐÅÏ ¼¼ÆÃ
                if (GameMaster.Instance.PATTERN == GameMaster.PatternMode.Spring)
                {
                    if (TrapGapAcc <= TrapGap)
                    {
                        if (TrapGapAcc == 0)
                        {// ¿ÞÂÊ
                            floor.Init(Floor.FloorIndex.Left);
                        }
                        else if (TrapGapAcc >= TrapGap)
                        {// ¿À¸¥ÂÊ
                            floor.Init(Floor.FloorIndex.Right);
                        }
                        else
                        {// ºóÄ­
                            floor.Init(Floor.FloorIndex.None);
                        }

                        TrapGapAcc++;
                    }
                    else
                    {
                        floor.Init(GetRandMid());
                    }
                }
                else
                {
                    floor.Init(GetRandMid());
                    TrapGapAcc = 0;
                }
            }
        }
    }

    private Floor.FloorIndex GetRandMid()
    {
        System.Random rand = new System.Random();
        return (Floor.FloorIndex)rand.Next((int)Floor.FloorIndex.Mid1, (int)Floor.FloorIndex.Mid2 + 1);
    }


}
