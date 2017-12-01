using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API04Message : MonoBehaviour 
{
    public GameObject target;

    private void Start()
    {
        //target.BroadcastMessage("Attack", null, SendMessageOptions.DontRequireReceiver);
        //target.SendMessage("Attack", null, SendMessageOptions.DontRequireReceiver);
        target.SendMessageUpwards("Attack", null, SendMessageOptions.DontRequireReceiver);
    }

}
