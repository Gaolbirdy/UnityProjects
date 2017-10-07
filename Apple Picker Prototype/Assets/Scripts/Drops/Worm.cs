using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour, IDrop
 {
    private void Update()
    {
        DropDestroy();
    }

    public void DropDestroy()
    {
        if (this.transform.position.y < GameArea.bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
