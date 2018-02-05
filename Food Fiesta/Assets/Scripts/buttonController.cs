using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour {

	public void Play(){
		SceneManager.LoadScene ("mainScene");
	}
	public void Restart(){
		SceneManager.LoadScene ("introScene");
	}
}
