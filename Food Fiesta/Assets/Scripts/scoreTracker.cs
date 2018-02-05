using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTracker : MonoBehaviour {

	int score;
	public Text scoreText;

	public Text endText;
	public Text restartButtonText;

	private string projectileName;

	//references the animator in the parent pbj
	Animator anim;

	void Start(){
		//starts the score out at 0
		score = 0;

		//removes the sample text for the win/lose text
		endText.text = " ";
		//sets the score text to "Score: 0"
		scoreText.text = "Score:" + score;

		//gets the animation component so we can alter the paramenters
		anim = GetComponentInParent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("projectile")) {
			//collects the name of the object that fell into the bowl so we can add points accordingly later
			projectileName = other.gameObject.name;

			//makes the item go away when it touches the bowl
			Destroy (other.gameObject);

			if(projectileDropper.gameInProgress == true){
				//adds points according to the specific type of object
				if (projectileName == "burrito(Clone)") {
					score++;	
				} else if (projectileName == "taco(Clone)") {
					score++;	
				} else if (projectileName == "jalapeno(Clone)") {
					score = score + 10;	
				} else if (projectileName == "bomb(Clone)") {
					Lose ();
				}
			}	

			//lets you win once you get 100 points
			if (score >= 100) {
				Win ();
			}

			//sets the score text
			scoreText.text = "Score:" + score;
		} 
	}

	void Win() {

		//sets the end text to say the winning message
		endText.text = "Great Job!";
		//sets the restart button to say replay
		restartButtonText.text = "Replay";

		//sets the speed in the animator controller
		anim.SetBool("Win", true);

		//stops the prijectiles from falling by setting the variable to false that is in hte conditional on the projectile dropper
		projectileDropper.gameInProgress = false;
	}

	void Lose() {

		//sets the end text to say the losing message
		endText.text = "Uh oh! You lost. Keep trying!";
		//sets the restart button to say retry
		restartButtonText.text = "Retry";

		anim.SetBool ("Lose", true);

		//stops the prijectiles from falling by setting the variable to false that is in hte conditional on the projectile dropper
		projectileDropper.gameInProgress = false;
	}
}
