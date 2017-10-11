using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 1f;

    private float nextFire = 0f;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
