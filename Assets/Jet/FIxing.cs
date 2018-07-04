using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIxing : MonoBehaviour
{

	private int Count;
	public Text countText;
	public float speed = 90.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		Debug.Log("plane pilot script added to: " + gameObject.name);
		Count = 0;
		

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias +
		                                 moveCamTo * (1.0f - bias);
		Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);
		
		 transform.position += transform.forward * Time.deltaTime * speed;
		
		speed -= transform.forward.y * Time.deltaTime * 50.0f;

		if (speed < 35.0f)
		{
			speed = 35.0f;
		}
		else if (speed > 40.0f)
		{
			speed = 90.0f;
		}

		transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

		float terrainHeighWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

		if (terrainHeighWhereWeAre > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x,
				terrainHeighWhereWeAre,
				transform.position.z);
		}

		if (transform.position.y < 4f)
		{
			Debug.Log("gameover");
		}

		if (transform.position.x < -25f)
		{
			Debug.Log("gameover");
		}

		if (transform.position.z < -30f)
		{
			Debug.Log("gameover");
		}

		if (transform.position.z > 2050f)
		{
			Debug.Log("gameover");
		}

		if (transform.position.x > 2050f)
		{
			Debug.Log("gameover");
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other != null)
		{
			print(other.gameObject.tag);
		}
		if (other.gameObject.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			Count = Count + 1;
			countText.text = "Score :  " + Count.ToString();
		}
	}
}