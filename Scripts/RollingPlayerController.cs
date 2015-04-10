using UnityEngine;
using System.Collections;

public class RollingPlayerController : MonoBehaviour 
{
	public float speed = 50;
	public float maxSpeed = 10;

	//Pre Physics Calculation
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
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
