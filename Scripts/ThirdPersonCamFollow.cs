using UnityEngine;
using System.Collections;

public class ThirdPersonCamFollow : MonoBehaviour {

	public float verticalOffset = 2f;
	public float cameraDistance = 3.5f;
	public float deadSpeed = 0.5f;
	public float camFollow = 0.2f;
	public float stillRotateSpeed = 100;
	public GameObject playerContainer;
	public GameObject player;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (rb.velocity.magnitude > deadSpeed) {
			Vector3 targetPosition = player.transform.position -
				rb.velocity.normalized * cameraDistance + 
				new Vector3 (0, verticalOffset, 0);
			transform.position += camFollow * (targetPosition - transform.position);
		}
		else 
		{
			transform.RotateAround(player.transform.position, Vector3.up, 
			                       Input.GetAxis("Horizontal") * Time.deltaTime * stillRotateSpeed);
		}
		transform.LookAt (player.transform);
	}
}
