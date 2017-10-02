using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
 {
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    //// 数组存篮筐的实现，不如用List取得要清除元素的索引方便
    //public GameObject[] basketArray;
    //public int basketIndex;

    void Start () 
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

    public void AppleDestroyed()
    {
        // 消除所有下落中的苹果
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        // 消除一个篮筐
        // 获取basketList中最后一个篮筐的序号
        int basketIndex = basketList.Count - 1;
        // 取得对该篮筐的引用
        GameObject tBasketGO = basketList[basketIndex];
        // 从列表中清除该篮筐并销毁该游戏对象，但是场景中该篮筐的游戏对象仍存在。先清除列表元素，再销毁，引用没问题吗？
        // 而tBasketGO这个游戏对象的引用是取自List里的该Index元素，该元素已被先清除，但引用依然有效而不是null? 因为List里也是存的引用吗
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // 失去所有篮筐后重新开始游戏，HighScore.score不会受到影响
        if (basketList.Count == 0)
            SceneManager.LoadScene("_Scene_0");

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
}
