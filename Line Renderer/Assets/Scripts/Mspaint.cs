using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mspaint : MonoBehaviour
 {
    public Material lineMaterial;

    private Color paintColor = Color.red;
    private float paintSize = 0.1f;
    private LineRenderer currentLine;
    private List<Vector3> positions = new List<Vector3>();
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private float lineDistance = 0.02f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = new GameObject();
            go.transform.SetParent(this.transform);
            currentLine = go.AddComponent<LineRenderer>();

            currentLine.material = lineMaterial;
            currentLine.startWidth = paintSize;
            currentLine.endWidth = paintSize;
            currentLine.startColor = paintColor;
            currentLine.endColor = paintColor;
            currentLine.numCornerVertices = 5;
            currentLine.numCapVertices = 5;

            Vector3 position = GetMousePoint();
            AddPosition(position);
            isMouseDown = true;
            lineDistance += 0.02f;
        }

        if (isMouseDown)
        {
            Vector3 position = GetMousePoint();
            if (Vector3.Distance(position, lastMousePosition) > 0.1f)
            {
                AddPosition(position);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentLine = null;
            positions.Clear();
            isMouseDown = false;
        }
    }

    private void AddPosition(Vector3 position)
    {
        // 得到鼠标点击位置的坐标，尝试用两种方法，GetMousePoint()和MousePoint()
        position.z -= lineDistance;
        positions.Add(position);
        currentLine.positionCount = positions.Count;
        //print(position);
        currentLine.SetPositions(positions.ToArray());
        lastMousePosition = position;
    }

    private Vector3 GetMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isCollider = Physics.Raycast(ray, out hit);
        if (isCollider)
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private Vector3 MousePoint()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        return mousePos3D;
    }

    #region OnValueChanged Method
    public void OnRedColorChanged(bool isOn)
    {
        if (isOn)
        {
            paintColor = Color.red;
        }
    }

    public void OnGreenColorChanged(bool isOn)
    {
        if (isOn)
        {
            paintColor = Color.green;
        }
    }

    public void OnBlueColorChanged(bool isOn)
    {
        if (isOn)
        {
            paintColor = Color.blue;
        }
    }

    public void OnPoint1Changed(bool isOn)
    {
        if (isOn)
        {
            paintSize = 0.1f;
        }
    }

    public void OnPoint2Changed(bool isOn)
    {
        if (isOn)
        {
            paintSize = 0.2f;
        }
    }

    public void OnPoint4Changed(bool isOn)
    {
        if (isOn)
        {
            paintSize = 0.4f;
        }
    }
    #endregion
}
