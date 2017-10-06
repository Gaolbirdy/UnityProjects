using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DifficultyLevel
{
    Easy = 0,
    Normal,
    Nightmare,
    Hell
}

public enum ScoreLevel
{
    Easy = 500,
    Normal = 1000,
    Nightmare = 1500,
    Hell = 2000
}

public class Difficulty
 {
    static public DifficultyLevel level;
    static private float[] speedParam = new float[4] {1.2f, 1.5f, 1.8f, 2f};

    static public void SetLevel()
    {
        DifficultyLevel currentLevel = level;
        if (ApplePicker.score <= (int)ScoreLevel.Easy)
            level = DifficultyLevel.Easy;
        else if (ApplePicker.score <= (int)ScoreLevel.Normal)
            level = DifficultyLevel.Normal;
        else if (ApplePicker.score <= (int)ScoreLevel.Nightmare)
            level = DifficultyLevel.Nightmare;
        else
            level = DifficultyLevel.Hell;
        if(currentLevel != level)
            ChangeProperty();
    }

    static public void ChangeProperty()
    {
        GameObject appleTreeGO = GameObject.Find("AppleTree");
        AppleTree apScript = appleTreeGO.GetComponent<AppleTree>();
        int levelIndex = (int)level;
        apScript.speed *= speedParam[levelIndex];

        //switch (level)
        //{
        //    case DifficultyLevel.Easy:
        //    default:
        //        break;
        //    case DifficultyLevel.Normal:
        //        apScript.speed *= speedParam[levelIndex];
        //        break;
        //    case DifficultyLevel.Nightmare:
        //        apScript.speed *= 2;
        //        break;
        //    case DifficultyLevel.Hell:
        //        apScript.speed *= 2;
        //        break;
        //}
    }
}
