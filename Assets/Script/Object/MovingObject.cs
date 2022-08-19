using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �Ǵ� ���� 
/// </summary>
public class MovingObject : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(MoveStart());
    }

    private IEnumerator MoveStart()
    {
        Vector3 vDir = Vector3.left;
        while(true)
        {
            Vector3 vPos = transform.position;
            vPos += vDir * Time.deltaTime * GameMaster.Instance.GameSpeed;
            transform.position = vPos;
            yield return null;
        }
    }
}
