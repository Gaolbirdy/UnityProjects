using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
 {

	private void Start () 
	{
        int highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        int finalScore = PlayerPrefs.GetInt("ApplePickerCurrentScore");
        string highScoreText = "\n\n高分纪录： " + highScore;
        string finalScoreText = "\n\n本次得分： " + finalScore;
        string recordText;

        if (finalScore < highScore)
        {
            recordText = "\n\n继续努力！";
        }
        else
            recordText = "\n\n厉害，封神了！";

        this.GetComponent<Text>().text += highScoreText + finalScoreText + recordText;
    }
}
