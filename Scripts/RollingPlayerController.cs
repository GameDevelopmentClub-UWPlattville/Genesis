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
	public float acceleration = 1400f;
	public float maxSpeed = 15f;
	public float turnSensitivity = 0.5f;
	public float inAirAcceleration = 0.45f;
	public float inAirDrag = 0.5f;
	public float inAirAngularDrag = 0.25f;
	public bool allowTrichording = false;
	public Camera ballCamera;

	private float dragInitial;
	private float angularDragInitial;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		dragInitial = rb.drag;
		angularDragInitial = rb.angularDrag;
	}

	//Pre Physics Calculation
	void FixedUpdate()
	{
		float cameraAngle = ballCamera.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;

		//Calculates amount of input that is left and right relative to the camera
		float moveHorizontal = Mathf.Sin (cameraAngle) * Input.GetAxis("Vertical") +
							   Mathf.Cos (cameraAngle) * turnSensitivity * Input.GetAxis("Horizontal");
		//Calculates amount of input that is forwards and backwards relative to the camera
		float moveVertical =  -Mathf.Sin (cameraAngle) * turnSensitivity * Input.GetAxis("Horizontal") +
							   Mathf.Cos (cameraAngle) * Input.GetAxis("Vertical");

		if (rb.velocity.magnitude < maxSpeed) 
		{
			if (IsGrounded ()) {
				rb.drag = dragInitial;
				rb.angularDrag = angularDragInitial;
				if(rb.velocity.magnitude > ballCamera.GetComponent<ThirdPersonCamFollow>().deadSpeed  
				   || Input.GetAxis("Vertical") > 0.125f)
				{
					Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
					if(allowTrichording)
						rb.AddForce (movement * acceleration * Time.deltaTime);
					else 
					{
						if(Input.GetAxis("Horizontal") > 0f && Input.GetAxis("Vertical") > 0f)
							rb.AddForce (movement.normalized * acceleration * Time.deltaTime);
						else
							rb.AddForce (movement * acceleration * Time.deltaTime);
					}
				}
			} 
			else 
			{
				rb.drag = inAirDrag;
				rb.angularDrag = inAirAngularDrag;
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				rb.AddForce (movement * acceleration * Time.deltaTime * inAirAcceleration);
			}
		}
	}

	public bool IsGrounded()
	{
		return Physics.Raycast (GetComponent<Rigidbody>().transform.position, Vector3.down, 0.5f);
	}


}
