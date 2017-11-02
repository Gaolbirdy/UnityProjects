using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour 
{
    // 可在代码任意位置访问的静态字段
    static public bool goalMet = false;

    private void OnTriggerEnter(Collider other)
    {
        // 当其他物体撞到触发器时
        // 检查是否是弹丸
        if (other.gameObject.tag == "Projectile")
        {
            // 如果是弹丸，设置goalMet为true
            Goal.goalMet = true;
            // 同时将颜色的不透明度设置得更高
            Color c = GetComponent<Renderer>().material.color;
            c.a = 1;
            GetComponent<Renderer>().material.color = c;
        }
    }
}
