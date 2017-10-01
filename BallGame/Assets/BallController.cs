using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
 {
    public float thrust = 40.0f;
    private Rigidbody rb;

    void Start () 
	{
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
            Application.Quit();
        }
    }

    void FixedUpdate () 
	{

    }

    void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 1.0f, 0) * thrust);
    }
}
