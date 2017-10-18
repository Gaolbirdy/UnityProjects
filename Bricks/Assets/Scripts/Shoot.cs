using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
    public GameObject bullet;
    public float speed = 5;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody rgb = b.GetComponent<Rigidbody>();
            rgb.velocity = transform.forward * speed;
        }
    }
}
