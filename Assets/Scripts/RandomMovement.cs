using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour 
{
	public float minSpeed, maxSpeed;	//The speed of movement
	
	// Update is called once per frame
	void Start () 
	{
		//update the velocity based on speed
		Vector3 randomMovement = new Vector3(Random.Range(minSpeed, maxSpeed), 0f, Random.Range(minSpeed, maxSpeed));
		rigidbody.velocity = randomMovement;
	}
}