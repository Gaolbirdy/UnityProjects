using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWTest : MonoBehaviour 
{
    public string url = "http://g.hiphotos.baidu.com/image/pic/item/241f95cad1c8a786c7dedcc46e09c93d71cf5007.jpg";
    
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
    }
}
