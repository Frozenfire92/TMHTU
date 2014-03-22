﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;				//speed of the player movement
	public float tilt;				//speed of the tilt
	public Boundary bounds; 		//boundary class to lock the player in the game world

	public float rotationSpeed;

	public GameObject bullet; 		//reference to the bullet prefab
	public Transform bulletSpawn; 	//reference to where the bullet will spawn
	public float fireRate = 0.5f; 	//the time in seconds between shots

	private float nextFireTime;		//keeps track of when the user can shoot again


	void Update() 
	{
		//If fire button is pressed and we are past the nextFireTime, shoot a bullet
		if (Input.GetButton("Fire1") && Time.time > nextFireTime)
		{
			nextFireTime = Time.time + fireRate;
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}

		//If Horizontal axis, rotate ship
		//float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		//rotation *= Time.deltaTime; 
		//transform.Rotate(0, rotation, 0);
	}


	//Updates based on physics ticks
	void FixedUpdate()
	{
		//Get user input
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		
		//Apply input to a Vector3, then apply that vector3 to the ships velocity
		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		rigidbody.velocity = movement * speed;

		//Get user input
		//if (Input.GetButton("Accelleration"))
		//{
		//	rigidbody.AddForce(Vector3.forward * speed);
		//}

		//Lock the ship within the game bounds
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, bounds.xMin, bounds.xMax),
				0f,
				Mathf.Clamp(rigidbody.position.z, bounds.zMin, bounds.zMax)
			);

		//Tilt the ship based on x velocity
		//rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -tilt);
	}
}