using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    public Rigidbody rb;
    public int force = 5;
    public Text text;
    public GameObject winText;

    private int score = 0;

    void Start () 
	{
        // 可以在检视面板把该GameObject赋给到自己脚本的刚体字段，前提是带有刚体组件
        //rb = GetComponent<Rigidbody>();
        text.text = score.ToString();
    }
	
	void FixedUpdate () 
	{
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h, 0, v) * force);
    }

    void OnCollisionEnter(Collision collision)
    {
        //string name = collision.collider.name;
        //print(name);
        if(collision.collider.tag == "PickUp")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            score++;
            text.text = score.ToString();
            transform.localScale *= (1 + score * 0.05f);
            if(score == 8)
            {
                winText.SetActive(true);
            }
            Destroy(other.gameObject);
        }
    }
}
