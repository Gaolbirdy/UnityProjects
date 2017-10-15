using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
 {
    // 用来初始化苹果实例的预设
    public GameObject applePrefab;
    // 大苹果预设
    public GameObject bigApplePrefab;
    // 坏苹果预设
    public GameObject badApplePrefab;
    // 虫子预设
    public GameObject wormPrefab;
    // 掉落物种类数组
    private GameObject[] drops;

    // 一般苹果产生概率
    private float chanceOfNormalApple
    {
        get
        {
            return 1 - sumOfOtheringChance();
        }
    }
    // 大苹果产生概率
    public float chanceOfBigApple = 0.1f;
    // 坏苹果产生概率
    public float chanceOfBadApple = 0.15f;
    // 虫子产生概率
    public float chanceOfWorm = 0.15f;
    // 掉落物概率数组
    private float[] chances;

    // 苹果树改变方向的概率
    public float chanceToChangeDirections = 0.1f;

    // 苹果树移动的速度，单位：米/秒；难度相关属性
    public float speed = 1f;

    // 掉落物出现的时间间隔；难度相关属性
    public float secondsBetweenDrops = 1f;

    void Start () 
	{
        // 每秒掉落一个苹果	
        // 测试结果是在这个方法开始调用后，repeatRate参数改变也无效了，所以无法影响这个难度
        InvokeRepeating("DropSomething", 2f, secondsBetweenDrops);
        BuildDropsStruct();
    }

    private void BuildDropsStruct()
    {
        drops = new GameObject[] { applePrefab, bigApplePrefab, badApplePrefab, wormPrefab };
        chances = new float[] { chanceOfNormalApple,chanceOfBigApple,chanceOfBadApple,chanceOfWorm };
    }

    private float sumOfOtheringChance()
    {
        return chanceOfBadApple + chanceOfBigApple + chanceOfWorm;
    }

    private void DropSomething()
    {
        GameObject something = RandomDrops();
        Instantiate(something, this.transform.position,this.transform.rotation);
    }

    private GameObject RandomDrops()
    {
        GameObject drop = null;
        float random = Random.value;
        float chance = 0.0f;
        for (int i = 0; i < chances.Length; i++)
        {
            chance += chances[i];
            if (random <= chance)
            {
                drop = drops[i];
                break;
            }
        }
        return drop;
    }

    void Update () 
	{
        // 基本运动
        Vector3 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        this.transform.position = pos;
        // 改变方向
        if (pos.x < -GameArea.leftAndRightEdge)
            speed = Mathf.Abs(speed); // 向右运动
        else if (pos.x > GameArea.leftAndRightEdge)
            speed = -Mathf.Abs(speed); // 向左运动
    }

    void FixedUpdate()
    {
        // 随机改变运动方向
        if (Random.value < chanceToChangeDirections)
            speed *= -1; // 改变方向
    }
}
