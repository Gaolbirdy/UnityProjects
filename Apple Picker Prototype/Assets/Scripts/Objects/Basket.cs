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


        //// 为什么GUIText直接new，而不是由别的对象赋值的引用，就会为null，Component也是；但是GameObject、GUISytle就可以new后直接访问
        //GUIText selfScore = new GUIText();
        //print(selfScore); // 输出null
        //print(selfScore.name); // 输出和赋值都会报错NullReferenceException
        //GUIStyle s = new GUIStyle();
        //print(s); // 正常
        //print(s.name); // 正常
        //Object o = new Object();
        //print(o); // 输出null
        //print(o.name); // 输出和赋值都会报错NullReferenceException
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
        switch (collideWith.tag)
        {
            case "Apple":
                {
                    Apple apScript = collideWith.GetComponent<Apple>();

                    Destroy(collideWith);
                    // 将scoreGT转换为整数值
                    ApplePicker.score = int.Parse(scoreGT.text);
                    // 每次接住苹果就为玩家加分
                    if (apScript.isBigApple)
                        ApplePicker.score += 400;
                    else
                        ApplePicker.score += 100;

                    // 将分数转化为字符串显示在屏幕上
                    scoreGT.text = ApplePicker.score.ToString();
                    // 监视最高分
                    if (ApplePicker.score > HighScore.highScore)
                        HighScore.highScore = ApplePicker.score;

                    //根据得分判断是否调整难度
                    Difficulty.SetLevel();
                    break;
                }
            case "BadApple":
                {
                    Destroy(collideWith);
                    // 将scoreGT转换为整数值
                    ApplePicker.score = int.Parse(scoreGT.text);
                    // 每次接住坏苹果就为玩家减分
                    ApplePicker.score -= 200;
                    // 将分数转化为字符串显示在屏幕上
                    scoreGT.text = ApplePicker.score.ToString();
                    break;
                }
            case "Worm":
                {
                    Destroy(collideWith);
                    // 失去一个篮筐
                    LoseBasket();
                    break;
                }
            default:
                break;
        }
    }

    void LoseBasket()
    {
        // 获取对主摄像机的ApplePicker组件的引用
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

        // 调用apScript的BasketDestroyed方法，刚好也是消除最上面的那个篮筐
        apScript.BasketDestroyed();
    }
}
