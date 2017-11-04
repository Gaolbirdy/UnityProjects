using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mspaint : MonoBehaviour
 {
    public Color paintColor = Color.red;
    public float paintSize = 0.1f;

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
