using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API11Input : MonoBehaviour 
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("KeyDown");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            print("KeyUp");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            print("Key");
        }
    }
}
