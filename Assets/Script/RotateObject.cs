using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int RotateSpeed = 1;
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);   
    }
}
