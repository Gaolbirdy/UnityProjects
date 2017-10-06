using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
 {

	private void Start () 
	{
        int highScore = ApplePicker.oldScoreRecord;
        int finalScore = PlayerPrefs.GetInt("ApplePickerCurrentScore");
        string recordText = PlayerPrefs.GetString("ApplePickerRecord");
        string highScoreText = "\n\n原高分纪录： " + highScore;
        string finalScoreText = "\n\n本次得分： " + finalScore;
        recordText = "\n\n" + recordText;
        this.GetComponent<Text>().text += highScoreText + finalScoreText + recordText;
    }
}
