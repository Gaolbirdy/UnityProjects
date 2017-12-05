using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API10Mathf : MonoBehaviour 
{
    public Transform cube;
    private int hp = 100;

    private void Start()
    {
        print(Mathf.Deg2Rad);
        print(Mathf.Rad2Deg);
        print(Mathf.Infinity);
        print(Mathf.NegativeInfinity);
        print(Mathf.PI);
        print(Mathf.Epsilon);
    }

    private void Update()
    {
        cube.position = new Vector3(Mathf.Clamp(Time.time, 1.0f, 3.0f), 0, 0);
        Debug.Log(Mathf.Clamp(Time.time, 1.0f, 3.0f));
    }

    private void TakeDamage()
    {
        hp -= 9;
        hp = Mathf.Clamp(hp, 0, 100);
    }
}
