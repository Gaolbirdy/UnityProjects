using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour 
{
	void Update () 
	{
        // Test Rotate
        if (this.tag == "PickUp")
            this.transform.Rotate(new Vector3(1, 1, 1) * 0.2f, Space.World);
        else
            this.transform.Rotate(new Vector3(1, 1, 0) * 0.2f, Space.Self);
    }
}
