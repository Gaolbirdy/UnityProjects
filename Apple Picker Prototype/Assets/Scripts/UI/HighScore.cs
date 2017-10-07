using UnityEngine;

public class HighScore : MonoBehaviour
 {
    // 重载场景时，这个静态变量不会被重置。为什么？ 重载场景时会重新创建游戏对象，以及游戏对象上的组件实例。
    // 而静态变量似乎从开始游戏运行就一直存在，即便重载场景也不会重新初始化，所以能够保存着更新过的值
    static public int highScore = 500;

    void Awake()
    {
        //PlayerPrefs.SetInt("ApplePickerHighScore", 0); // 调试用，清空记录
        // 如果ApplePickerHighScore已经存在，则读取其值
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        // 将最高得分赋给ApplePikcerHighScore
        else
            PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }

    void Update () 
	{
        GUIText gt = this.GetComponent<GUIText>();
        gt.text = "High Score: " + highScore;
        // 如有必要，则更新PlayerPrefs中的Update ApplePikcerHighScore
        if (highScore > PlayerPrefs.GetInt("ApplePickerHighScore"))
            PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }
}
