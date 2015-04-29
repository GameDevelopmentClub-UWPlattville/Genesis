using UnityEngine;
using System.Collections;

public class SpeedBoostPowerUp : MonoBehaviour 
{
    public RollingPlayerController player;
    public float boost;
    public float duration = 3.0f;
    private float time;
    private float temp;

	// Use this for initialization
	void Start () 
    {
        temp = player.acceleration;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > time)
        {
            player.acceleration = temp;
            player.GetComponent<ParticleSystem>().Stop();
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        time = Time.time + duration;
        player.acceleration = boost * player.acceleration;
        player.GetComponent<ParticleSystem>().Play();
    }
}
