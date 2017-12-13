using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API16Camera : MonoBehaviour 
{
    private Camera c;

    private void Start()
    {
        c = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        
    }
}
