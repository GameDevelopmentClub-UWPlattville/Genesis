using UnityEngine;
using System.Collections;

public class Spin_Script : MonoBehaviour
{
	public Vector3 eulerAngleVelocity;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody> ().AddTorque (0, 1000.0f, 0);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//float torque = Mathf.Sin (Time.time);
		//transform.Rotate(new Vector3(0, 10.0f, 0));
		//GetComponent<Rigidbody> ().AddTorque (0, 10.0f, 0);
		//GetComponent<Rigidbody> ().rotation() > 0;
		//Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		//rb.MoveRotation(rb.rotation * deltaRotation);

		rb.angularVelocity = (eulerAngleVelocity);
	}
}
