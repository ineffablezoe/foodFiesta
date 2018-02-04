using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTracker : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("projectile")) {
			//makes the item go away when it touches the bowl
			Destroy(other.gameObject);
		} 
	}
}
