using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadApple : Apple
 {
    // 不继承Apple，直接用Drop基类的
    public override void DropDestroy()
    {
        if (this.transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
