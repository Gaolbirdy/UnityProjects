using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API02Time : MonoBehaviour 
{
    public Transform cube;
    public int runCount = 10000;

    private void Start()
    {
        //Debug.Log("Time.deltaTime: " + Time.deltaTime);
        //Debug.Log("Time.fixedDeltaTime: " + Time.fixedDeltaTime);
        //Debug.Log("Time.fixedTime: " + Time.fixedTime);
        //Debug.Log("Time.frameCount: " + Time.frameCount);
        //Debug.Log("Time.realtimeSinceStartup: " + Time.realtimeSinceStartup);
        //Debug.Log("Time.smoothDeltaTime: " + Time.smoothDeltaTime);
        //Debug.Log("Time.time: " + Time.time);
        //Debug.Log("Time.timeScale: " + Time.timeScale);
        //Debug.Log("Time.timeSinceLevelLoad: " + Time.timeSinceLevelLoad);
        //Debug.Log("Time.unscaledTime: " + Time.unscaledTime);

        float time00 = Time.realtimeSinceStartup;
        for (int i = 0; i < runCount; i++)
        {
            Method0();
        }
        float time0 = Time.realtimeSinceStartup;
        Debug.Log(time0 - time00);

        float time1 = Time.realtimeSinceStartup;
        for (int i = 0; i < runCount; i++)
        {
            Method1();
        }
        float time2 = Time.realtimeSinceStartup;
        Debug.Log(time2 - time1);

        float time3 = Time.realtimeSinceStartup;
        for (int i = 0; i < runCount; i++)
        {
            Method2();
        }
        float time4 = Time.realtimeSinceStartup;
        Debug.Log(time4 - time3);
    }

    private void Update()
    {
        //Debug.Log("Time.deltaTime: " + Time.deltaTime);
        //Debug.Log("Time.fixedDeltaTime: " + Time.fixedDeltaTime);
        //Debug.Log("Time.fixedTime: " + Time.fixedTime);
        //Debug.Log("Time.frameCount: " + Time.frameCount);
        //Debug.Log("Time.realtimeSinceStartup: " + Time.realtimeSinceStartup);
        //Debug.Log("Time.smoothDeltaTime: " + Time.smoothDeltaTime);
        //Debug.Log("Time.time: " + Time.time);
        //Debug.Log("Time.timeScale: " + Time.timeScale);
        //Debug.Log("Time.timeSinceLevelLoad: " + Time.timeSinceLevelLoad);
        //Debug.Log("Time.unscaledTime: " + Time.unscaledTime);
        //cube.Translate(Vector3.forward * Time.deltaTime * 3);
        //Time.timeScale = 3f;
    }

    void Method0()
    {

    }

    void Method1()
    {
        int i = 2;
        i += 2;
        i += 2;
    }

    void Method2()
    {
        int i = 2;
        i *= 2;
        i *= 2;
    }
}
