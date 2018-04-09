using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public float myCoolTimer = 30;
	public Text timer;

	// Use this for initialization
	void Start () {
		timer = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		myCoolTimer -= Time.deltaTime;
		timer.text = myCoolTimer.ToString ("f0");
	
		if (myCoolTimer < 1) {
			FindObjectOfType<GameManager> ().EndGame ();
		}
}
}