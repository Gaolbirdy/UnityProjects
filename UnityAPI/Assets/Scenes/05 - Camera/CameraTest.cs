using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour 
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //print(ray.direction.magnitude);
        //Debug.DrawRay(ray.origin, ray.direction);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100);
        RaycastHit hit;
        bool isCollider = Physics.Raycast(ray, out hit);
        Debug.Log(hit.collider);
    }
}
