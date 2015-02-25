using UnityEngine;
using System.Collections;

public class EnnemyBoltMover : MonoBehaviour {

	public float speed;
	
	void Start(){
		rigidbody.velocity = transform.forward * speed;
	}
}
