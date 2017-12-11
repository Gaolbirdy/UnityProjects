using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API13Random : MonoBehaviour 
{
    public Transform cube;

    private void Start()
    {
        //Random.InitState((int)System.DateTime.Now.Ticks);
    }

    private void Update()
    {
        //print(Random.Range(4, 10));
        //print(Random.Range(4, 5f));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print(Random.Range(4, 100));
            //print((int)System.DateTime.Now.Ticks);
            //cube.transform.position = Random.insideUnitCircle * 5;
            cube.transform.position = Random.insideUnitSphere * 5;
        }
    }
}
