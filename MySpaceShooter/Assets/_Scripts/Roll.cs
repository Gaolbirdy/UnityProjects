using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour 
{
    public float rollSpeed = 0.2f;
    public GameObject backgroundPrefab;
    private Vector3 rebornPos;

    private bool isReborned = false;

    private void Start()
    {
        rebornPos = this.transform.position;
    }

    private void Update ()
	{
        this.GetComponent<Rigidbody>().velocity = -transform.up * rollSpeed;
        if (this.transform.position.z < 0 && !isReborned)
        {
            Instantiate(backgroundPrefab, rebornPos, this.transform.rotation);
            isReborned = true;
        }
	}
}
