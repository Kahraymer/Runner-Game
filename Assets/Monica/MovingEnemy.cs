using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

	private float birdX;
	private float birdY;
	private float birdZ;

	private bool birdFlying = false;


	private float waitGuess = 490;

	// Use this for initialization
	void Start () {
		//transform.localScale = new Vector3(0,0,0); // Not initially visible on the screen
		birdX = transform.localPosition.x;
		birdY = transform.localPosition.y;
		birdZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		waitGuess--;

		// Only move the bird once the pc is about to enter the screen
		if (!birdFlying && (waitGuess == 0)) {
			for (int i = 0; i < 5; i++) {
				birdX -= 1;
				transform.localPosition = new Vector3 (birdX,birdY,birdZ);
			}
			birdFlying = true;
		}


	}
}
