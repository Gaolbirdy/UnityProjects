using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API01EventFunction : MonoBehaviour 
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void Update()
    {
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    private void OnApplicationPause()
    {
        Debug.Log("OnApplicationPause");
    }

    //private void OnApplicationPause(bool pause)
    //{
    //    Debug.Log("OnApplicationPause");
    //}

    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
    }

    private void Reset()
    {
        Debug.Log("Reset");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
