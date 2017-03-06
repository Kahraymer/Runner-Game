using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour {
	public AudioClip landingSound;

	private const float START_DELAY = 1.5f; // This is approx. the length of the first explosion animation
	private const float LANDING_RATE = 0.1f;
	private const float INIT_XY = 50;
	private const float FINAL_XY = 27;
	private const float Z = 1;
	private bool text_triggered = false;
		

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0,0,0); // Not initially visible on the screen
	}

	// Update is called once per frame
	void Update () {
		if (!text_triggered) {
			StartCoroutine(landingText());
			text_triggered = true;
		}
	}

	IEnumerator landingText() {
		yield return new WaitForSeconds (START_DELAY);
		transform.localScale = new Vector3(INIT_XY,INIT_XY,Z);
		float diff = INIT_XY - FINAL_XY;
		for (int i = 5; i >= 1; i--) {
			transform.localScale = new Vector3 (INIT_XY - diff/i,INIT_XY - diff/i,Z);
			yield return new WaitForSeconds (LANDING_RATE);
		}
		transform.localScale = new Vector3 (FINAL_XY,FINAL_XY,Z);
		AudioSource.PlayClipAtPoint(landingSound, transform.position);
	}
}
