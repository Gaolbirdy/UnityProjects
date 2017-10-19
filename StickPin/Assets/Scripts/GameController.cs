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
    private bool isGameOver = false;
    private int score = 0;
    private Camera mainCamera;

    private void Start()
    {
        SpawnPin();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (isGameOver)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            currentPin.StartFly();
            SpawnPin();
            AddScore();
        }       
    }

    private void SpawnPin()
    {
        currentPin = Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        //if (isGameOver)
        //    return; // 多余了，已经GameOver则不会再调用到此方法了
        GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;
        isGameOver = true;
        StartCoroutine(GameOverAnimation());
    }

    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private IEnumerator GameOverAnimation()
    {
        while (true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, speed * Time.deltaTime);
            if (Mathf.Abs(mainCamera.orthographicSize - targetSize) < 0.01f)
                break;
            yield return 0;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
