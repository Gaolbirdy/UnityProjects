using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour 
{
    static public MissionDemolition S;  // 单例对象

    // 在Unity检视面板中设置的字段
    public GameObject[] castles;    // 存储所有城堡对象的数组
    public GUIText gtLevel; // GT_Level界面文字
    public GUIText gtScore; // GT_Score界面文字
    public Vector3 castlePos;   // 放置城堡的位置

    public bool __________________________________;

    // 在代码中动态设置的变量



}
