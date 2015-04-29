using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour 
{
	public GameObject top;
	public GameObject bottom;
	public float speed = 10;
	public GameObject cameraLocation;
	public GameObject camera;
	public bool isActive = true;
	private bool moveDown = false;

	void OnTriggerStay(Collider other)
	{
		moveDown = false;
		if (isActive) 
		{
			if(GetComponent<Rigidbody> ().transform.position.y < top.transform.position.y)
			{
				GetComponent<Rigidbody> ().MovePosition(transform.position + new Vector3 (0, speed / 1000f, 0));
				camera.transform.position = cameraLocation.transform.position;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		moveDown = true;
	}

	void Update()
	{
		if(moveDown && isActive)
		{
			GetComponent<Rigidbody> ().MovePosition(transform.position + new Vector3 (0, -speed / 1000f, 0));
			if(GetComponent<Rigidbody> ().transform.position.y < bottom.transform.position.y)
				moveDown = false;
		}
	}

}
