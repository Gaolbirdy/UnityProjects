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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = new GameObject();   // 空
            go.transform.SetParent(this.transform);
            currentLine = go.AddComponent<LineRenderer>();
            currentLine.material = lineMaterial;
            currentLine.startWidth = paintSize;
            currentLine.endWidth = paintSize;
            currentLine.startColor = paintColor;
            currentLine.endColor = paintColor;
            currentLine.numCornerVertices = 5;
            currentLine.numCapVertices = 5;
            AddPosition();
            isMouseDown = true;
        }

        if (isMouseDown)
        {
            AddPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentLine = null;
            positions.Clear();
            isMouseDown = false;
        }
    }

    private void AddPosition()
    {
        Vector3 position = GetMousePoint();
        //position.z -= 0.01f;
        positions.Add(position);
        currentLine.positionCount = positions.Count;
        //print(position);
        currentLine.SetPositions(positions.ToArray());
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
