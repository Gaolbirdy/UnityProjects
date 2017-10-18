using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public Transform startPoint;
    public Transform spawnPoint;
    public GameObject pinPrefab;

    private Pin currentPin;
    private bool isGameOver = false;

    private void Start()
    {
        SpawnPin();
    }

    private void Update()
    {
        if (isGameOver)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            currentPin.StartFly();
            SpawnPin();
        }       
    }

    private void SpawnPin()
    {
        currentPin = Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        if (isGameOver)
            return;
        GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;
        isGameOver = true;
    }
}
