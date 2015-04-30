using UnityEngine;
using System.Collections;

public class KillZScript : MonoBehaviour 
{
	public GameObject spawnPoint;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			other.gameObject.transform.position = spawnPoint.transform.position;
		}
	}
}
