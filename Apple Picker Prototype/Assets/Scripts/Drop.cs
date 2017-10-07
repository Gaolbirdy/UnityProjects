using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
 {
    public static float bottomY = -20f;
	
	private void Update () 
	{
        DropDestroy();
    }

    public virtual void DropDestroy()
    {
        if (this.transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
