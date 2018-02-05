﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTracker : MonoBehaviour {

	int score;
	public Text scoreText;

	void Start(){
		score = 0;

		scoreText.text = "Score:" + score;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("projectile")) {
			//makes the item go away when it touches the bowl
			Destroy(other.gameObject);
			score++;
			scoreText.text = "Score:" + score;
		} 
	}
}
