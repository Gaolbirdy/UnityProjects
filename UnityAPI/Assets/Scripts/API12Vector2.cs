using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API12Vector2 : MonoBehaviour 
{
    private void Start()
    {
        print(Vector2.down);
        print(Vector2.up);
        print(Vector2.left);
        print(Vector2.right);
        print(Vector2.one);
        print(Vector2.zero);

        Vector2 a = new Vector2(2, 2);
        Vector2 b = new Vector2(3, 4);
        print(a.magnitude);
        print(a.sqrMagnitude);
        print(b.magnitude);
        print(b.sqrMagnitude);

        print(a.normalized);
        print(b.normalized);

        print(a.x + "," + a.y);
        a.Normalize();
        print(a[0] + "," + a[1]);
    }
}
