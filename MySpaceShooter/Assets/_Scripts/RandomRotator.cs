using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
    public float tumble = 10.0f;
	// Use this for initialization
	void Start ()
    {
        // 最大角速度受限
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
