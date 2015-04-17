using UnityEngine;
using System.Collections;

public class Tilt_Script : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		float torque = Mathf.Sin (Time.time);
		transform.Rotate(new Vector3(0, 0, torque));
	}
}
