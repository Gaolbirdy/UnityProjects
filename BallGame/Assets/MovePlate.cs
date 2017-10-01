using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
 {
    public float speed = 5.0f;

    void Update () 
	{
        float h = Input.GetAxis("Horizontal");
        // 直接位移， Vector3.right * h * speed 作为每秒位移量
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }
}
