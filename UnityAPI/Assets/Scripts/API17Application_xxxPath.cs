using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API17Application_xxxPath : MonoBehaviour 
{
    private void Start()
    {
        print(Application.dataPath);
        print(Application.streamingAssetsPath);
        print(Application.persistentDataPath);
        print(Application.temporaryCachePath);
    }
}
