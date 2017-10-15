using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 作为GameController，游戏主流程
public class ApplePicker : MonoBehaviour
 {
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    static public int score;
    // 在游戏开始存着原纪录，用于在结束界面作比较；不直接用PlayerPrefs里的值比较，因为游戏过程中它会更新
    static public int oldScoreRecord;

    //// 数组存篮筐的实现，不如用List取得要清除元素的索引方便
    //public GameObject[] basketArray;
    //public int basketIndex;

    void Start () 
	{
        SetScore();
        SetBaskets();
        Difficulty.SetLevel();
    }

    private void SetScore()
    {
        // 静态变量在类的定义那初始化后，即便重载场景也不会重新初始化，还保留原值；所以一定要在方法里初始化
        score = 0;
        oldScoreRecord = PlayerPrefs.GetInt("ApplePickerHighScore");
    }

    private void SetBaskets()
    {
        basketList = new List<GameObject>();

        //// 数组存篮筐的实现
        //basketArray = new GameObject[numBaskets];
        //// 初始化篮筐数组的待清除元素的索引
        //basketIndex = basketArray.Length - 1;

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);

            //// 数组存篮筐的实现
            //basketArray[i] = tBasketGO;
        }
    }

    private void Update()
    {
        IsGameOver();
    }

    private void IsGameOver()
    {
        // 失去所有篮筐后游戏结束，HighScore.score不会受到影响
        if (basketList.Count == 0)
        {
            SetRecord();
            GameOverScene();
        }
    }

    private void GameOverScene()
    {
        SceneManager.LoadScene("_Scene_GameOver");
    }

    public void AppleDestroyed()
    {
        // 消除所有下落中的苹果
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // 消除一个篮筐
        BasketDestroyed();
    }

    public void BasketDestroyed()
    {
        // 获取basketList中最后一个篮筐的序号
        int basketIndex = basketList.Count - 1;
        // 取得对该篮筐的引用
        GameObject tBasketGO = basketList[basketIndex];
        // 从列表中清除该篮筐并销毁该游戏对象，但是场景中该篮筐的游戏对象仍存在。先清除列表元素，再销毁，引用没问题吗？
        // 而tBasketGO这个游戏对象的引用是取自List里的该Index元素，该元素已被先清除，但引用依然有效而不是null? 因为List里也是存的引用吗
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //// 注释调RemoveAt后测试，销毁后还能输出，看起来是到下一帧才真正销毁
        //print(basketIndex + " " + basketList[basketIndex] + " 名字 " + basketList[basketIndex].name);

        //// 数组存篮筐的实现
        //// 获取篮筐数组中最后一个（场景中最上面一个）篮筐的引用
        //if(basketIndex >= 0)
        //{
        //    GameObject tBaskeGO = basketArray[basketIndex];
        //    // 从数组中清除该篮筐并销毁该游戏对象，但是场景中该篮筐的游戏对象仍存在。先清除数组元素，再销毁，引用没问题吗？
        //    // 而tBasketGO这个游戏对象的引用是取自数组里的该Index元素，该元素已被先清除，但引用依然有效而不是null? 因为数组里也是存的引用吗
        //    basketArray[basketIndex] = null;
        //    Destroy(tBaskeGO);
        //    // Index--预设为下一次如果要清除时的数组元素索引
        //    basketIndex--;
        //}
    }

    private void SetRecord()
    {
        // 将本局游戏分数写入PlayerPrefs，用于GameOver后切换到新场景界面显示分数；还不会别的方式在不同场景中传递数据
        PlayerPrefs.SetInt("ApplePickerCurrentScore", ApplePicker.score);

        if (ApplePicker.score > ApplePicker.oldScoreRecord)
            PlayerPrefs.SetString("ApplePickerRecord", "厉害，封神了！");
        else if (ApplePicker.score == ApplePicker.oldScoreRecord)
            PlayerPrefs.SetString("ApplePickerRecord", "追平啦，一步之遥！");
        else
            PlayerPrefs.SetString("ApplePickerRecord", "有差距，继续努力！");
    }
}
