using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float MoveSpeed;
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
    }
}
