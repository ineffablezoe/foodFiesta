﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDropper : MonoBehaviour {

	//will help pick which item to drop
	int selectionNumber;

	//all of the items that can be dropped
	GameObject burrito;
	GameObject taco;
	GameObject jalapeno;
	GameObject bomb;

	//will hold which of the items we selected to be dropped
	GameObject droppedItem;

	//keeps track of the time between items being dropped
	public float timeLeft;

	float initialTimeLeft;

	//randomizes where items are dropped from
	int xPosition;

	// Use this for initialization
	void Start () {

		//gets all of the items from the resource folder
		burrito = Resources.Load("burrito") as GameObject;
		taco = Resources.Load("taco") as GameObject;
		jalapeno = Resources.Load("jalapeno") as GameObject;
		bomb = Resources.Load("bomb") as GameObject;

		//sets the initial value of the time left so that we can reset the time later
		initialTimeLeft = timeLeft;

	}

	// Update is called once per frame
	void Update () {

		//generates a random number to select an item
		selectionNumber = Random.Range (0, 4);

		//selects an item using the random number we generated
		if (selectionNumber == 0) {
			droppedItem = burrito;
		} else if (selectionNumber == 1) {
			droppedItem = taco;
		} else if (selectionNumber == 2) {
			droppedItem = jalapeno;
		} else if (selectionNumber == 3) {
			droppedItem = bomb;
		}

		//ticks the time down
		timeLeft -= Time.deltaTime;

		//if (SceneManager.GetActiveScene().name != "character_selection"){
		//drops an item when the time between item drops is up
		if (timeLeft <= 0) {	
			Drop ();
			//resets the timer
			timeLeft = initialTimeLeft;
		}
		//}
	}

	void Drop() {

		xPosition = Random.Range (-15, 15);

		Instantiate(droppedItem, new Vector3(xPosition, 5, 0), Quaternion.identity);
		//GameObject projectile = Instantiate (droppedItem) as GameObject;
		//projectile.transform.position = new xPosition;

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("bowl")) {
			//makes the item go away when it touches the bowl
			droppedItem.SetActive (false);
		} else if (other.gameObject.CompareTag ("floor")) {
			//makes the item go away when it hits the floor so they don't accumulate
			droppedItem.SetActive(false);
		}
	}
}
