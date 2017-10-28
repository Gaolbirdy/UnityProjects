using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour 
{
    // 调试碰撞脚本调用顺序用
    static private int id = 0;

    private void Start()
    {
        name += " " + id.ToString();
        print(name + " created");
        id++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(name + " begin");
        print(collision.name + " 撞进来了");
        GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
        if (gc.IsGameOver)
        {
            print(name + " return");
            return; // 两个针头互相碰撞后，避免会调用两次
        }
        if (collision.tag == "PinHead")
        {
            gc.GameOver();
        }
        print(name + " end");
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
