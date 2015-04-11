using UnityEngine;
using System.Collections;

public class ThirdPersonCamFollow : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () 
	{
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//transform.position = player.transform.position + offset;
		if (Input.GetKey ("q"))
			transform.RotateAround (player.transform.position, Vector3.up, 100 * Time.deltaTime);
		if (Input.GetKey ("e"))
			transform.RotateAround (player.transform.position, Vector3.up, -100 * Time.deltaTime);
	}
}
