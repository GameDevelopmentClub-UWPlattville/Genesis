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
		SetStartPosition ();
	}

	public void SetStartPosition()
	{
		transform.position = player.transform.position + new Vector3 (0, verticalOffset, -cameraDistance);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 planarPlayerSpeed = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
		if (planarPlayerSpeed.magnitude > deadSpeed) {
			Vector3 playerPlanarVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			Vector3 targetPosition = player.transform.position -
				  playerPlanarVelocity.normalized * cameraDistance + 
				new Vector3 (0, verticalOffset, 0);
			transform.position += camFollow * (targetPosition - transform.position);
		}
		else 
		{
			transform.RotateAround(player.transform.position, Vector3.up, 
			                       Input.GetAxis("Horizontal") * Time.deltaTime * stillRotateSpeed);
			transform.position = new Vector3(transform.position.x, player.transform.position.y + verticalOffset, transform.position.z);
		}
		transform.LookAt (player.transform);
	}
}
