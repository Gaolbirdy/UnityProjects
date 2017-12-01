using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API06MonoBehaviour : MonoBehaviour 
{
    public Cube cube;

    private void Start()
    {
        Debug.Log(this.isActiveAndEnabled);
        Debug.Log(this.enabled);
        enabled = false;
        Debug.Log(name);
        Debug.Log(tag);
        Debug.Log(gameObject);
        Debug.Log(transform);
        Debug.Log(this);

        print("haha");

        Debug.Log(cube.isActiveAndEnabled);
        Debug.Log(cube.enabled);
        cube.enabled = false;
        Debug.Log(cube.name);
        Debug.Log(cube.tag);
        Debug.Log(cube.gameObject);
        Debug.Log(cube.transform);
        Debug.Log(cube);

    }
}
