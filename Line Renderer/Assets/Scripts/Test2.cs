using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
 {
    private GameObject LineRendererGameObject;
    private LineRenderer lineRenderer;
    private int lineLength = 4;
    private Vector3 v0 = new Vector3(1, 0, 0);
    private Vector3 v1 = new Vector3(0, 1, 0);
    private Vector3 v2 = new Vector3(0, 0, 1);
    private Vector3 v3 = new Vector3(1, 0, 0);

    private void Start () 
	{
        LineRendererGameObject = GameObject.Find("Test2");
        lineRenderer = LineRendererGameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = lineLength;
        lineRenderer.SetPosition(0, v0);
        lineRenderer.SetPosition(1, v1);
        lineRenderer.SetPosition(2, v2);
        lineRenderer.SetPosition(3, v3);
    }

    private void Update () 
	{
        //lineRenderer.SetPosition(0, v0);
        //lineRenderer.SetPosition(1, v1);
        //lineRenderer.SetPosition(2, v2);
        //lineRenderer.SetPosition(3, v3);
    }
}
