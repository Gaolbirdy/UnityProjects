using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API10Mathf : MonoBehaviour 
{
    public Transform cube;
    public int a = 8;
    public int b = 20;
    public float t = 0;
    public float speed = 3;

    private int hp = 100;

    private void Start()
    {
        //print(Mathf.Deg2Rad);
        //print(Mathf.Rad2Deg);
        //print(Mathf.Infinity);
        //print(Mathf.NegativeInfinity);
        //print(Mathf.PI);
        //print(Mathf.Epsilon);

        //print(Mathf.ClosestPowerOfTwo(2));
        //print(Mathf.ClosestPowerOfTwo(14));
        //print(Mathf.Max(1, 2));
        //print(Mathf.Max(1, 2, 5, 3, 10));
        //print(Mathf.Min(1, 2));
        //print(Mathf.Min(1, 2, 5, 3, 10));
        //print(Mathf.Pow(4, 3));
        //print(Mathf.Sqrt(3));

        //cube.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        //cube.position = new Vector3(Mathf.Clamp(Time.time, 1.0f, 3.0f), 0, 0);
        //Debug.Log(Mathf.Clamp(Time.time, 1.0f, 3.0f));
        //print(Mathf.Lerp(a, b, t));

        //float x = cube.position.x;
        ////float newX = Mathf.Lerp(x, 10, Time.deltaTime);
        //float newX = Mathf.MoveTowards(x, 10, Time.deltaTime * speed);
        //cube.position = new Vector3(newX, cube.position.y, cube.position.z);

        //print(Mathf.MoveTowards(a, b, t));

        //print(Mathf.PingPong(t, 20));

        cube.position = new Vector3(5 + Mathf.PingPong(Time.time * speed, 5), cube.position.y, cube.position.z);
    }

    private void TakeDamage()
    {
        hp -= 9;
        hp = Mathf.Clamp(hp, 0, 100);
    }
}
