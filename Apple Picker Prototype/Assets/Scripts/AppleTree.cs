using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
 {
    // 用来初始化苹果实例的预设
    public GameObject applePrefab;
    // 大苹果预设
    public GameObject bigApplePrefab;
    // 大苹果产生概率
    public float chanceOfBigApple = 0.1f;

    // 坏苹果预设
    public GameObject badApplePrefab;
    // 坏苹果产生概率
    public float chanceOfBadApple = 0.15f;

    // 虫子预设
    public GameObject wormPrefab;
    // 虫子产生概率
    public float chanceOfWorm = 0.15f;

    // 苹果树的活动区域，到达边界时则改变方向
    public float leftAndRightEdge = 10f;

    // 苹果树改变方向的概率
    public float chanceToChangeDirections = 0.1f;

    // 苹果树移动的速度，单位：米/秒；难度相关属性
    public float speed = 1f;

    // 苹果出现的时间间隔；难度相关属性
    public float secondsBetweenAppleDrops = 1f;

    public float[,] difficultyLevel = new float[3, 2]; 

	void Start () 
	{
        // 每秒掉落一个苹果	
        // 测试结果是在这个方法开始调用后，repeatRate参数改变也无效了，所以无法影响这个难度
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}

    void DropApple()
    {
        GameObject drop;
        float chance = Random.value;
        if (chance < chanceOfBadApple)
            drop = Instantiate(badApplePrefab) as GameObject;
        else if (chance < (chanceOfBadApple + chanceOfWorm))
            drop = Instantiate(wormPrefab) as GameObject;
        else
        {
            if (Random.value < chanceOfBigApple)
            {
                drop = Instantiate(bigApplePrefab) as GameObject;
            }
            else
                drop = Instantiate(applePrefab) as GameObject;
        }
        drop.transform.position = this.transform.position;
    }

    void Update () 
	{
        // 基本运动
        Vector3 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        this.transform.position = pos;
        // 改变方向
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed); // 向右运动
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed); // 向左运动
    }

    void FixedUpdate()
    {
        // 随机改变运动方向
        if (Random.value < chanceToChangeDirections)
            speed *= -1; // 改变方向
    }
}
