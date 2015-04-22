using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour 
{
	void OnTriggerStay(Collider other)
	{
		GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0.01f, 0));
	}
}
