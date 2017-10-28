using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public Transform startPoint;
    public Transform spawnPoint;
    public GameObject pinPrefab;
    public Text scoreText;
    public float speed = 1.0f;
    public float targetSize = 4.0f;

    private Pin currentPin;
    private int score = 0;
    private Camera mainCamera;

    private bool isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        private set
        {
            isGameOver = value;
        }
    }

    private void Start()
    {
        SpawnPin();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsGameOver)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            // 到达待命位置才会响应输入而发射，避免“目前逻辑有可能还没达到待发射位置，就点了左键发射（未能通过Update把isReach设为true）”
            if (currentPin.isReach) 
            {
                currentPin.StartFly();
                SpawnPin();
                AddScore();
            }
        }
    }

    private void SpawnPin()
    {
        currentPin = Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        //GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;
        IsGameOver = true;
        StartCoroutine(GameOverAnimation());
    }

    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private IEnumerator GameOverAnimation()
    {
        // 模拟Update
        while (true)
        {
            //print("while loop");
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, speed * Time.deltaTime);
            // 摄像机Size的变化ok了，就跳出。不判断Color的插值变化了，都同步插值变化，会差不多。
            if (Mathf.Abs(mainCamera.orthographicSize - targetSize) < 0.01f)
                break;
            // 不管数值为几，都是等一帧。返回的是迭代器IEnumerator 的 currentvalue ，对U3D协同来说，这个值是数字的话没有什么意义，可以是任意值 
            yield return 0;
        }
        //print("while done");
        yield return new WaitForSeconds(1.0f);
        //print("wait done");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
