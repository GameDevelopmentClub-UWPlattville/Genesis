using UnityEngine;
using System.Collections;

public class RollingPlayerController : MonoBehaviour 
{
	public float speed = 50;
	public float maxSpeed = 10;
	public Camera ballCamera;

	//Pre Physics Calculation
	void FixedUpdate()
	{
		//This Block handles the movement relative to the camera
		float moveHorizontal = Mathf.Sin (ballCamera.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad) *
			Input.GetAxis("Vertical") +
			Mathf.Cos (ballCamera.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad) *
			Input.GetAxis("Horizontal");;
		float moveVertical = -Mathf.Sin (ballCamera.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad) *
			Input.GetAxis("Horizontal") +
			Mathf.Cos (ballCamera.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad) *
			Input.GetAxis("Vertical");

		//This block handles the max speed calculations
		if (GetComponent<Rigidbody> ().velocity.x > maxSpeed &&
			moveHorizontal > 0)
			moveHorizontal = 0;
		if (GetComponent<Rigidbody> ().velocity.x * -1 > maxSpeed &&
		    moveHorizontal < 0)
			moveHorizontal = 0;
		if (GetComponent<Rigidbody> ().velocity.z > maxSpeed &&
		    moveVertical > 0)
			moveVertical = 0;
		if (GetComponent<Rigidbody> ().velocity.z * -1 > maxSpeed &&
		    moveVertical < 0)
			moveVertical = 0;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime * 100);
	}
}
