using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
        if (gc.IsGameOver)
            return; // 两个针头互相碰撞后，避免会调用两次
        if (collision.tag == "PinHead")
        {
            gc.GameOver();
        }
    }

    //private void Update()
    //{
    //    Vector3 pos = transform.localPosition;
    //    pos.y = 0;
    //    transform.localPosition = pos;
    //    // 随着parent的转动，它的local y坐标会发现变化，不过数值非常小，接近于初始值0。为什么会变化呢，可能是误差。
    //    print(transform.localPosition.y);
    //}
}
