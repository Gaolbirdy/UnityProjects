using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API14Quaternion : MonoBehaviour 
{
    public Transform cube;

    private void Start()
    {
        print(cube.eulerAngles);
        print(cube.localEulerAngles);
        print(cube.rotation);
        print(cube.localRotation);
    }

    private void Update()
    {
        
    }
}
