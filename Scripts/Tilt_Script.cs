using UnityEngine;
using System.Collections;

public class Tilt_Script : MonoBehaviour 
{
    public float multiplier = 1.0f;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		float torque = Mathf.Cos (Time.time) * multiplier * Time.deltaTime * 75;
		transform.Rotate(new Vector3(0, 0, torque));
	}
}
