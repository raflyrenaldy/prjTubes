using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

	public GameObject playerExplosion;


	void OnTriggerEnter (Collider other) 
	{
		Debug.Log ("Collision Detected");

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}
