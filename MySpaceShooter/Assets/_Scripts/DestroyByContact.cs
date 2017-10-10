using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public int scoreValue;

    // 用拖动GameController游戏对象赋值试试，此脚本是绑在prefab上，不能通过拖动当前场景中对象实例来赋值，因为prefab还可以用在其他场景上
    private GameController gameController; 

    void Start()
    {
        GameObject go = GameObject.FindWithTag("GameController"); // GameObject.FindGameObjectWithTag
        if (go != null)
        {
            gameController = go.GetComponent<GameController>();
        }
        else
            Debug.Log("找不到tag为GameController的对象");
        if (gameController == null)
            Debug.Log("找不到脚本GameController.cs");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        switch (this.tag)
        {
            case "Enemy":
                Instantiate(enemyExplosion, transform.position, transform.rotation);
                scoreValue *= 5;
                break;
            default:
                Instantiate(explosion, transform.position, transform.rotation);
                break;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
