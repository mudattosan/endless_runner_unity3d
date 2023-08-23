using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuondary : MonoBehaviour
{
    public static float leftSide = 0f;
    public static float rightSide = 7f;
    public float internalLeft;
    public float internalRight;
    void Start()
    {
        
    }

    
    void Update()
    {
        internalLeft = leftSide;    
        internalRight = rightSide;
    }
}
