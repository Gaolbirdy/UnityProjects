using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
 {
    private LineRenderer lineRenderer;
    private Vector3 position;
    private int index = 0;
    private int LengthOfLineRenderer = 0;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.1f;
    }

    private void Update()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        if(Input.GetMouseButton(0))
        {
            position = Camera.main.ScreenToWorldPoint(new Vector3
                (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 1f));
            LengthOfLineRenderer++;
            lineRenderer.positionCount = LengthOfLineRenderer;
        }
        while (index < LengthOfLineRenderer)
        {
            lineRenderer.SetPosition(index, position);
            index++;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("当前鼠标X轴位置：" + Input.mousePosition.x);
        GUILayout.Label("当前鼠标Y轴位置：" + Input.mousePosition.y);
        GUILayout.Label("当前鼠标Z轴位置：" + Input.mousePosition.z);
        GUILayout.Label("线段X轴位置：" + position.x);
        GUILayout.Label("线段Y轴位置：" + position.y);
        GUILayout.Label("线段Z轴位置：" + position.z);
        GUILayout.Label("lineRenderer.positionCount：" + lineRenderer.positionCount);
    }
}
