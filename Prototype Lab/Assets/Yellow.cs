using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour 
{
    public GameObject newGoal;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "yellow")
        {
            print("score yellow");
            Destroy(other.gameObject);
            GameObject.Find("Link").GetComponent<Link>().scoreYellow += 1;
            //Instantiate(newGoal);
            //newGoal.transform.position = new Vector3(Random.insideUnitCircle.x * 15, Random.insideUnitCircle.y * 15, 0);
        }
    }
    
}
