using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour 
{
    public float speed = 3.0f;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        cc.SimpleMove(new Vector3(h, 0, v) * speed);
        //print(cc.isGrounded);
        //cc.Move(new Vector3(h, 0, v) * speed * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.collider);
    }

}
