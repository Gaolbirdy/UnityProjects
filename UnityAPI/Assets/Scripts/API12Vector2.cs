using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API12Vector2 : MonoBehaviour 
{
    private void Start()
    {
        //print(Vector2.down);
        //print(Vector2.up);
        //print(Vector2.left);
        //print(Vector2.right);
        //print(Vector2.one);
        //print(Vector2.zero);

        //Vector2 a = new Vector2(2, 2);
        //Vector2 b = new Vector2(3, 4);
        //print(a.magnitude);
        //print(a.sqrMagnitude);
        //print(b.magnitude);
        //print(b.sqrMagnitude);

        //print(a.normalized);
        //print(b.normalized);

        //print(a.x + "," + a.y);
        //a.Normalize();
        //print(a[0] + "," + a[1]);

        //向量是结构体，是值类型，要整体赋值
        //transform.position = new Vector3(3, 3, 3);
        //Vector3 pos = transform.position;
        //pos.x = 10;
        //transform.position = pos;

        //Vector2 a = new Vector2(2, 2);
        //Vector2 b = new Vector2(3, 4);
        //Vector2 c = new Vector2(3, 0);

        //print(Vector2.Angle(a, b));
        //print(Vector2.Angle(b, c));
        //print(Vector2.ClampMagnitude(c, 2));
        //print(Vector2.Distance(b, c));

        //print(Vector2.Lerp(a, b, 0.5f));
        //print(Vector2.LerpUnclamped(a, b, 0.5f));

        //print(Vector2.Lerp(a, b, 2f));
        //print(Vector2.LerpUnclamped(a, b, 2f));

        //print(Vector2.Max(a, b));
        //print(Vector2.Min(a, b));
    }

    public Vector2 a = new Vector2(2, 2);
    public Vector2 target = new Vector2(10, 3);

    private void Update()
    {
        a = Vector2.MoveTowards(a, target, Time.deltaTime);
    }
}
