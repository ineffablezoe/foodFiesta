using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llamaController : MonoBehaviour {

	Rigidbody2D rb;

	public float maxSpeed = 10f;
	private bool facingRight = true;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		//if we're moving right and not facing right, flip us
		if (move > 0 && !facingRight) {
			Flip ();
		//if we're moving right and not facing right, flip us
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	//flips the character so we're facing the other direction
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
