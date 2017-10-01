using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
        this.GetComponent<Rigidbody>().velocity = new Vector3(-10.0f, 9.0f, 0.0f);
	}

    void OnBecameInvisible() // 场景摄像机也看不到游戏对象时
    {
        Destroy(this.gameObject);
    }
}
