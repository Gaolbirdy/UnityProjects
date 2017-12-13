using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API14Quaternion : MonoBehaviour 
{
    public Transform cube;

    public Transform player;
    public Transform enemy;

    private void Start()
    {
        //print(cube.eulerAngles);
        //print(cube.localEulerAngles);
        //print(cube.rotation);
        //print(cube.localRotation);

        //cube.eulerAngles = new Vector3(45, 45, 45);
        cube.rotation = Quaternion.Euler(new Vector3(45, 45, 45));
        //print(cube.rotation.eulerAngles);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))    // 按键down后，自己完成旋转
        {
            Vector3 dir = enemy.position - player.position;
            //print(dir);
            dir.y = 0;
            //print(dir);
            Quaternion target = Quaternion.LookRotation(dir);
            player.rotation = Quaternion.Lerp(player.rotation, target, Time.deltaTime); // 中间变量lerp？
            //player.rotation = Quaternion.Slerp(player.rotation, target, Time.deltaTime);
        }
    }
}
