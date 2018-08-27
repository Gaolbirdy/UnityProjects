using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour 
{
    public GameObject newGoal;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "red")
        {
            print("score red");
            Destroy(other.gameObject);
            GameObject.Find("Link").GetComponent<Link>().scoreRed += 1;
            
        }
        print(GameObject.FindGameObjectsWithTag("red").Length);

    }
}
