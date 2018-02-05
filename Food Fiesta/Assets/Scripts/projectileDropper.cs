using System.Collections;
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

	//keeps track of whether the game is in progress to know if it should drop items
	public static bool gameInProgress = true;

	//keeps track of the time between items being dropped
	public float timeLeft;

	//holds the start time of the timer so we can reset the timer
	float initialTimeLeft;

	//randomizes where items are dropped from
	int xPosition;

	void Start () {

		//gets all of the items from the resource folder
		burrito = Resources.Load("burrito") as GameObject;
		taco = Resources.Load("taco") as GameObject;
		jalapeno = Resources.Load("jalapeno") as GameObject;
		bomb = Resources.Load("bomb") as GameObject;

		//sets the initial value of the time left so that we can reset the time later
		initialTimeLeft = timeLeft;

	}
		
	void Update () {

		//generates a random number to select an item to drop
		selectionNumber = Random.Range (0, 4);

		//uses the number we generated to set the item that will be dropped
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


		if (timeLeft <= 0 && gameInProgress) {	
			Drop ();
			//resets the timer
			timeLeft = initialTimeLeft;
		}
	}

	void Drop() {

		//generates a number to decide where the item will be dropped from
		xPosition = Random.Range (-13, 13);

		//drops the item
		Instantiate(droppedItem, new Vector3(xPosition, 5, 0), Quaternion.identity);
		//GameObject projectile = Instantiate (droppedItem) as GameObject;
		//projectile.transform.position = new xPosition;

	}

	/*void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("floor")) {
			//makes the item go away when it hits the floor so they don't accumulate
			Destroy (droppedItem.gameObject);
		}
		if (other.gameObject.CompareTag ( "bowl"))
		{
			droppedItem.SetActive (false);
		}
	}*/
}
