using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private void Update()
    {
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);

        //bool isCollider = Physics.Raycast(ray);
        RaycastHit hit;
        //bool isCollider = Physics.Raycast(ray, out hit);
        bool isCollider = Physics.Raycast(ray, Mathf.Infinity, LayerMask.GetMask("Enemy1", "Enemy2"));

        Debug.Log(isCollider);
        //Debug.Log(hit.collider);
        //Debug.Log(hit.point);
        Debug.DrawRay(transform.position + transform.forward, transform.forward, Color.red);
    }
}
