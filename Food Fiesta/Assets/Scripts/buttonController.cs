using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour {

	//used when you go to the main scene from the intro scene
	public void Play(){
		SceneManager.LoadScene ("mainScene");
	}

	//used when you go back to the intro from the main scene
	public void Restart(){
		SceneManager.LoadScene ("introScene");
		//this makes sure that the items will fall if they're going from a restart
		projectileDropper.gameInProgress = true;
	}
}
