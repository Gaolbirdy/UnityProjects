using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API07Invoke : MonoBehaviour 
{
    private void Start()
    {
        //Invoke("Attack", 3f);
        InvokeRepeating("Attack", 4f, 2f);
        CancelInvoke("Attack");
    }

    private void Update()
    {
        bool res = IsInvoking("Attack");
        print(res);
    }

    void Attack()
    {
        print("攻击目标");
    }
}
