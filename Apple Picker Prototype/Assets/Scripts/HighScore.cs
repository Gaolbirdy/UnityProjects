using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
 {
    // 重载场景时，这个静态变量不会被重置。为什么？ 重载场景时会重新创建游戏对象，以及游戏对象上的组件实例。
    // 而静态变量似乎从开始游戏运行就一直存在，即便重载场景也不会重新初始化，所以能够保存着更新过的值
    static public int score = 500;

    void Awake()
    {
        // 如果ApplePickerHighScore已经存在，则读取其值
        if (PlayerPrefs.HasKey("ApplePikcerHighScore"))
            score = PlayerPrefs.GetInt("ApplePikcerHighScore");
        // 将最高得分赋给ApplePikcerHighScore
        else
            PlayerPrefs.SetInt("ApplePikcerHighScore", score);
    }

    void Update () 
	{
        GUIText gt = this.GetComponent<GUIText>();
        gt.text = "High Score: " + score;
        // 如有必要，则更新PlayerPrefs中的Update ApplePikcerHighScore
        if (score > PlayerPrefs.GetInt("ApplePikcerHighScore"))
            PlayerPrefs.SetInt("ApplePikcerHighScore", score);
    }
}
