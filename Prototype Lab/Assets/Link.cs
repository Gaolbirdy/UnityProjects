using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
    public bool isRedRotate = true;
    public Quaternion yellowRot;
    public Quaternion redRot;
    public Quaternion linkRot;
    public Transform yellow;
    public Transform red;
    public Text textRed;
    public Text textYellow;
    public int scoreRed  = 0;
    public int scoreYellow = 0;

    public GameObject yellowGoal;
    public GameObject redGoal;

    private void Start()
    {
        yellow = transform.GetChild(0);
        red = transform.GetChild(1);

        yellowRot = yellow.rotation;
        redRot = red.rotation;

        linkRot = transform.rotation;

        textRed = GameObject.Find("ScoreRed").GetComponent<Text>();
        textYellow = GameObject.Find("ScoreYellow").GetComponent<Text>();



    }

    private void Update()
    {
        //print(gameObject.transform.rotation);

        //if(isRedRotate)
        //{
        //    redRot.z += 0.01f;
        //    red.rotation = redRot;
        //}
        //else
        //{
        //    yellowRot.z -= 0.01f;
        //    yellow.rotation = yellowRot;
        //}


        if (Input.GetMouseButtonDown(0))
        {
            isRedRotate = isRedRotate ? false : true;
        }

        if (isRedRotate)
        {
            //linkRot.z += 0.01f;
            //transform.rotation = linkRot;
            transform.RotateAround(red.position, Vector3.forward, 1.5f);
        }
        else
        {
            //linkRot.z -= 0.01f;
            //transform.rotation = linkRot;
            transform.RotateAround(yellow.position, Vector3.back, 1.5f);
        }

        textRed.text = "红球得分:" + scoreRed;
        textYellow.text = "黄球得分:" + scoreYellow;

        if (GameObject.FindGameObjectsWithTag("red").Length < 1)
        {
            Instantiate(redGoal);
            redGoal.transform.position = new Vector3(Random.insideUnitCircle.x * 15, Random.insideUnitCircle.y * 15, 0);
        }

        if (GameObject.FindGameObjectsWithTag("yellow").Length < 1)
        {
            Instantiate(yellowGoal);
            yellowGoal.transform.position = new Vector3(Random.insideUnitCircle.x * 15, Random.insideUnitCircle.y * 15, 0);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (gameObject.name == "Link" && (other.gameObject.tag == "red" || other.gameObject.tag == "yellow"))
    //    {

    //    }
    //        //print("over");
    //}
}
