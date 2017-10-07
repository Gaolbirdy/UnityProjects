using UnityEngine;
using UnityEngine.UI;

public class DifficultyText : MonoBehaviour
 {
    private void Update () 
	{
        GUIText difficultGT = this.GetComponent<GUIText>();
        switch (Difficulty.level)
        {
            case DifficultyLevel.Easy:
            default:
                difficultGT.text = "简单难度";
                break;
            case DifficultyLevel.Normal:
                difficultGT.text = "普通难度";
                break;
            case DifficultyLevel.Nightmare:
                difficultGT.text = "噩梦难度";
                break;
            case DifficultyLevel.Hell:
                difficultGT.text = "地狱难度";
                break;
        }
        // 过一会儿消失
    }
}
