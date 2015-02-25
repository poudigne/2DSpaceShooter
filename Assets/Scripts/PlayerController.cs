﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin = -5.8f;
	public float xMax = 5.8f;
	public float zMin = -3.1f; 
	public float zMax = 11f;
}


public class PlayerController : MonoBehaviour {

	public float speed = 10 ;
	public float tilt = 4;
	public float fireRate = 0.25f;
	public float accSpeed = 10.0f;
	public Boundary boundary;


	public GameObject shot;
	public Transform shotSpawn;

	private float nextFire = 0.0f;

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire){

			nextFire = Time.time + fireRate;
			Instantiate ( shot, shotSpawn.position, shotSpawn.rotation);	
			audio.Play();
		}
		Vector3 direction = Vector3.zero;
		direction.x = Input.acceleration.x;
		direction.z = Input.acceleration.y;
		
		if ( direction.sqrMagnitude > 1 )
		{
			direction.Normalize();
		}
		direction *= Time.deltaTime;
		transform.Translate( direction * accSpeed );
	}


	void FixedUpdate(){
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		//rigidbody.velocity = movement * speed;
		
		

		ResetSpaceShipPosition (rigidbody);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	void ResetSpaceShipPosition(Rigidbody rigidBody){
		float x = Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax);
		float z = Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax);
		rigidbody.position = new Vector3 (x,0.0f,z);
	}



}
