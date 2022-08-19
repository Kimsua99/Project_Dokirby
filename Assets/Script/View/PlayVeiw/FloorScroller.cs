using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorScroller : MonoBehaviour
{
    public Transform[] floors;

    private float leftPosX = 0f;
    private float rightPosX = 0f;
    private float xScreenHalfSize;
    private float yScreenHalfSize;

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

            // 변경 시점
            if (floors[i].position.x + 1f < leftPosX) // 월드 pos 값,
            {
                Vector3 nextPos = floors[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX + 3f, nextPos.y, nextPos.z);
                floors[i].position = nextPos;
            }
        }
    }
}
