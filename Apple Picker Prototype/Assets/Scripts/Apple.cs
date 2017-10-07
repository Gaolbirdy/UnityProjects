using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Drop
 {
    public bool isBigApple = false;

    public override void DropDestroy()
    {
        if (this.transform.position.y < bottomY)
        {
            // 下面销毁了所有掉落中的苹果了，这句不是必要了
            Destroy(this.gameObject);

            // 获取对主摄像机的ApplePicker组件的引用
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // 调用apScript的AppleDestroyed方法
            apScript.AppleDestroyed();
        }
    }

    // 在苹果类里去销毁所有苹果也可以，当一个苹果掉出下界时
    //void AppleDestroyed()
    //{
    //    GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
    //    foreach (GameObject tGO in tAppleArray)
    //    {
    //        Destroy(tGO);
    //    }
    //}
}
