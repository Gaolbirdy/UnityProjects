using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour 
{
    public float speed = 5;
    public float stickPosY = 0.7f;
    // 是否达到待发射的初始位置
    public bool isReach = false;

    // 是否在飞往目标位置的过程中
    public bool isFly = false;
    private Transform startPoint;
    private Transform circle;
    private Vector3 targetCirclePos;

    private void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        //circle = GameObject.FindGameObjectWithTag("Circle").transform;
        targetCirclePos = circle.position;
        targetCirclePos.y -= stickPosY;
    }

    private void Update()
    {
        if (isFly == false)
        {
            // 还没按左键前的分支，飞往待发射的初始位置
            if (isReach == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    //transform.position = startPoint.position;
                    isReach = true;
                }
            }
        }
        // 按左键后的分支，飞往目标位置
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCirclePos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetCirclePos) < 0.05f)
            {
                transform.position = targetCirclePos; // 会让针插入后高度一致
                // 自身不再移动，而是随着parent的transform变换，转动
                transform.parent = circle;
                isFly = false;
                GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
                gc.AddScore();
            }
        }
    }

    public void StartFly()
    {
        isFly = true;
        //// 目前逻辑有可能还没达到待发射位置，就点了左键发射（未能通过Update把isReach设为true）。所以需在此处把isReach设为true，否则还会一直飞往待发射位置
        //isReach = true;
    }
}
