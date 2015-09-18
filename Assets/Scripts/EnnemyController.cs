using UnityEngine;
using System.Collections;

public class EnnemyController : MonoBehaviour {

	public float speed = 0.01f ;
	public float fireRate = 0.6f;	
	
	public GameObject shot;
	public Transform shotSpawn;
	
	private float nextFire = 0.5f;
	
	void Update(){
		if (Time.time > nextFire){
			
			nextFire = Time.time + fireRate;
			Instantiate ( shot, shotSpawn.position, shotSpawn.rotation);	
			GetComponent<AudioSource>().Play();
		}
		transform.Translate( transform.forward * speed );
	}
}
