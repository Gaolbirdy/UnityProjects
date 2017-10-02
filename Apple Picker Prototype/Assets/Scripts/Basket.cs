using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
 {
    public GUIText scoreGT;

    void Start()
    {
        // 查找ScoreCounter游戏对象，获取它的引用，通过引用去修改属性值。
        // 没法直接在Basket预设里把ScoreCounter预设的GUIText组件赋值过来，因为预设的游戏对象没有被实例化
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // 获取该游戏对象的GUIText组件
        scoreGT = scoreGO.GetComponent<GUIText>();
        //将初始分数设置为0
        scoreGT.text = "0";
    }

    void Update()
    {
        // 从Input中获取鼠标在屏幕中的当前位置，此时mousePos2D.z默认为0
        Vector3 mousePos2D = Input.mousePosition;

        // 摄像机的z坐标决定在三维空间中将鼠标沿z轴向前移动多远，0的话就相当于主摄像机的位置
        mousePos2D.z = -Camera.main.transform.position.z;

        // 将该点从二维屏幕空间转换为三维游戏世界空间
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // 将篮筐的x位置移动到鼠标处的x位置处
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // 检查与篮筐碰撞的是什么对象
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
            // 将scoreGT转换为整数值
            int score = int.Parse(scoreGT.text);
            // 每次接住苹果就为玩家加分
            score += 100;
            // 将分数转化为字符串显示在屏幕上
            scoreGT.text = score.ToString();
        }
    }
}
