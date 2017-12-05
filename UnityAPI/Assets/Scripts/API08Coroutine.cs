using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API08Coroutine : MonoBehaviour 
{
    public GameObject cube;

    //private IEnumerator ie;
    private Coroutine ct;

    private void Start()
    {
        //print("haha");
        ////ChangerColor();
        //StartCoroutine(ChangerColor());
        //// 协程方法开启后，会继续运行下面的代码，不会等协程方法运行结束才继续执行
        //print("hahaha");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ie = Fade();
            //StartCoroutine(ie);
            //ct = StartCoroutine(Fade());
            StartCoroutine("Fade");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //StopCoroutine(ct);
            StopCoroutine("Fade");
        }
    }

    IEnumerator Fade()
    {
        for (; ; )
        {
            //cube.GetComponent<MeshRenderer>().material.color = new Color(i, i, i, i);
            Color color = cube.GetComponent<MeshRenderer>().material.color;
            Color newColor = Color.Lerp(color, Color.red, 0.02f);
            cube.GetComponent<MeshRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0.02f);
            if (Mathf.Abs(Color.red.g - newColor.g) <= 0.01f)
            {
                break;
            }
        }
    }

    // Coroutines
    // 1，返回值是IEnumerator
    // 2，返回参数的时候使用yield return null / 0
    // 3，协程方法的调用StartCoroutine(Method())
    IEnumerator ChangerColor()
    {
        print("hahaColor");
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 1; i++)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        print("hahaColor");
        yield return null;
    }
}
