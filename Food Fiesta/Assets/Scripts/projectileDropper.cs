using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDropper : MonoBehaviour {

	//just for shooting purposes
	public GameObject player;

	int selectionNumber;

	GameObject burrito;
	GameObject taco;
	GameObject jalapeno;
	GameObject bomb;

	GameObject droppedItem;

	int xPosition;

	// Use this for initialization
	void Start () {

		burrito = Resources.Load("burrito") as GameObject;
		taco = Resources.Load("taco") as GameObject;
		jalapeno = Resources.Load("jalapeno") as GameObject;
		bomb = Resources.Load("bomb") as GameObject;


	}

	// Update is called once per frame
	void Update () {
		selectionNumber = Random.Range (0, 4);

		if (selectionNumber == 0) {
			droppedItem = burrito;
		} else if (selectionNumber == 1) {
			droppedItem = taco;
		} else if (selectionNumber == 2) {
			droppedItem = jalapeno;
		} else if (selectionNumber == 3) {
			droppedItem = bomb;
		}
			
		//if (SceneManager.GetActiveScene().name != "character_selection"){
			Drop();
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
<<<<<<< HEAD
		if (other.gameObject.CompareTag ("floor")) {
			//makes the item go away when it hits the floor so they don't accumulate
			Destroy(droppedItem.gameObject);
=======
		if (other.gameObject.CompareTag ( "bowl"))
		{
			droppedItem.SetActive (false);
>>>>>>> parent of 9e7383f... projectiles fall periodically
		}
	}
}
