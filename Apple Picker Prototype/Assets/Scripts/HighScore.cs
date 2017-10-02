using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
 {
    static public int score = 1000;

    void Update () 
	{
        GUIText gt = this.GetComponent<GUIText>();
        gt.text = "High Score: " + score;
	}
}
