using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool GameOver = false;
	public float restartDelay = 1f;


	public void EndGame(){

		if (GameOver == false) {
			GameOver = true;
			Debug.Log ("Game Over");
			Invoke ("Restart", restartDelay);
		}
	}

	void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
