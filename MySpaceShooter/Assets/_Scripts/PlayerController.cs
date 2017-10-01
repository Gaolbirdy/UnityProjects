using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
 {
    public float hSpeed = 5.0f;
    public float vSpeed = 5.0f;
    public float tilt = 4.0f;
    public Vector3 movement;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Boundary boundary;
    private float nextFire = 0.0f;


    void FixedUpdate () 
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // 此例为什么改为由刚体实现移动
        movement = new Vector3(moveHorizontal * hSpeed, 0.0f, moveVertical * vSpeed);
        if(rb != null)
        { 
            rb.velocity = movement;
            // 刚体的positon和transform.position有些区别，并没有直接去更新transform.position
            rb.position = BoundPosition(rb.position, boundary);
            // 刚体的rotation和transform.rotation有些区别
            // 将三个轴旋转角度的欧拉角转为四元数
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    // 限制边界位置
    private Vector3 BoundPosition(Vector3 position, Boundary boundary)
    {
        return new Vector3(
            Mathf.Clamp(position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(position.z, boundary.zMin, boundary.zMax));
    }
}
