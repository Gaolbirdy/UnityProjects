using UnityEngine;

public class FollowTarget : MonoBehaviour 
{
    public Transform playerTransform;

    private Vector3 offset;

	void Start () 
	{
        this.offset = this.transform.position - this.playerTransform.position;
        //this.offset = this.playerTransform.position - this.transform.position;
	}
	
	void Update () 
	{
        this.transform.position = this.playerTransform.position + this.offset;
        //this.transform.position = this.playerTransform.position - this.offset;
    }
}
