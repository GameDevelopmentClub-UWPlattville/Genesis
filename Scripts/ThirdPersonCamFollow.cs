using UnityEngine;
using System.Collections;

public class ThirdPersonCamFollow : MonoBehaviour {

	public GameObject player;
	public float camFollow = 0.05f;
	public Camera ballCamera;
	public GameObject playerContainer;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Target position = ball location - 4 * the direction of movement + 2y.
		Vector3 targetPosition = player.transform.position -
			player.GetComponent<Rigidbody> ().velocity.normalized *
			3 + new Vector3 (0, 2, 0);
		if(player.GetComponent<Rigidbody> ().velocity.magnitude > 0.25)
			transform.position += camFollow * (targetPosition - transform.position);
		transform.LookAt (player.transform);
	}
}
