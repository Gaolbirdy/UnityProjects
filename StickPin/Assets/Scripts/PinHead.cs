using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
        if (gc.IsGameOver)
            return; // 两个针头碰撞后，避免会调用两次
        if (collision.tag == "PinHead")
        {
            gc.GameOver();
        }
    }
}
