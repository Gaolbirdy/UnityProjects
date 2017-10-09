using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private Vector3 spawnPosition = Vector3.zero; 
    private Quaternion spawnRotatoin;
    private int score;
    private bool gameOver;
    private bool restart;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (gameOver)
            {
                restartText.enabled = true;
                restart = true;
                break;
            }
            for (int i = 0; i < hazardCount; i++)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotatoin = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotatoin);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
	// Use this for initialization
	void Start () 
	{
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves());
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "得分：" + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.enabled = true;
    }

    void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
        }
    }
}
