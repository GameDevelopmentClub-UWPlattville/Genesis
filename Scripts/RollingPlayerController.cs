/* 
 * The rolling Player Controller is a controller class
 * That handles the movement for a rolling character.
 * In fixed update the game takes input from the veritcal
 * and horizontal axes (WASD and Arrow keys) and converts
 * them into movement components based on the camera's angle.
 * 
 * It also has a function that caps the speed at a top speed
 * 
 * Author: Josiah Stewart
 */
using UnityEngine;
using System.Collections;

public class RollingPlayerController : MonoBehaviour 
{
	public float acceleration = 50;
	public float maxSpeed = 10;
	public Camera ballCamera;

	private float angularDragInitial;

	void Start()
	{
		angularDragInitial = GetComponent<Rigidbody> ().angularDrag;
	}

	//Pre Physics Calculation
	void FixedUpdate()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		float cameraAngle = ballCamera.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;

		//Calculates amount of input that is left and right relative to the camera
		float moveHorizontal = Mathf.Sin (cameraAngle) * Input.GetAxis("Vertical") +
							   Mathf.Cos (cameraAngle) * Input.GetAxis("Horizontal");
		//Calculates amount of input that is forwards and backwards relative to the camera
		float moveVertical =  -Mathf.Sin (cameraAngle) * Input.GetAxis("Horizontal") +
							   Mathf.Cos (cameraAngle) * Input.GetAxis("Vertical");
		
		if (rb.velocity.x > maxSpeed && moveHorizontal > 0)
			moveHorizontal = 0;
		if (rb.velocity.x * -1 > maxSpeed && moveHorizontal < 0)
			moveHorizontal = 0;
		if (rb.velocity.z > maxSpeed && moveVertical > 0)
			moveVertical = 0;
		if (rb.velocity.z * -1 > maxSpeed && moveVertical < 0)
			moveVertical = 0;

		Vector3 movement = new Vector3 (moveHorizontal * 0.85f, 0.0f, moveVertical);

		Debug.Log (GetComponent<Rigidbody> ().angularDrag);
		if (IsGrounded ()) 
		{
			GetComponent<Rigidbody> ().angularDrag = angularDragInitial;
			GetComponent<Rigidbody> ().AddForce (movement * acceleration * Time.deltaTime * 100);
		} else 
		{
			GetComponent<Rigidbody> ().angularDrag = 0;
			GetComponent<Rigidbody> ().AddForce (movement * acceleration * Time.deltaTime * 10);
		}
	}

	public bool IsGrounded()
	{
		return Physics.Raycast (GetComponent<Rigidbody>().transform.position, Vector3.down, 0.5f);
	}
}
