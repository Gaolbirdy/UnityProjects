using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour 
{
    private void Update()
    {
        Debug.Log(Input.touches.Length);
        if (Input.touches.Length > 0)
        {
            Touch touch1 = Input.touches[0];
            //touch1.position;
            TouchPhase phase = touch1.phase;
            
        }
    }
}
