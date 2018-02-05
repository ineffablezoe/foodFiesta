using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floorProjectileDestroyer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("projectile")) {
			//makes the item go away when it touches the bowl
			Destroy(other.gameObject);
		} 
	}

	public void PlayAgain(){
		SceneManager.LoadScene ("mainScene");
	}
}
