﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour 
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

	private void Start () 
	{
        startPosition = this.transform.position;
	}

    private void Update ()
	{
        float newPosition = Mathf.Repeat(Time.time * this.scrollSpeed, this.tileSizeZ);
        float t = Mathf.Repeat(5.1f, 4);
        print(t);
        this.transform.position = this.startPosition + Vector3.forward * newPosition;
	}
}
