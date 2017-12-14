using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API16Camera : MonoBehaviour 
{
    private Camera mainCamera;

    private void Start()
    {
        //c = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //bool isCollider = Physics.Raycast(ray, out hit);
        //if (isCollider)
        //{
        //    Debug.Log(hit.collider);
        //}

        //Ray ray = mainCamera.ScreenPointToRay(new Vector3(200, 200, 0));
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
    }
}
