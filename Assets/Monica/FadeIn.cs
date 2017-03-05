using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	private const float START_DELAY = 1.5f; // This is approx. the length of the first explosion animation

	// Variables for fade in effect
	private const float FADE_RATE = .01f; // This is approx. the length of the first explosion animation
	private bool play_triggered = false;
	private Image play_button;
	private Color button_color;
	private Text play_text;
	private Color text_color;


	// Use this for initialization
	void Start () {
		// Initialize button fade
		play_button = GetComponent<Image> ();
		button_color = play_button.color;
		button_color.a = 0; // transparent
		play_button.color = button_color;

		// Initialize text fade
		play_text = GetComponentInChildren<Text> ();
		text_color = play_text.color;
		text_color.a = 0;
		play_text.color = text_color;
	}
	
	// Update is called once per frame
	void Update () {
		if (!play_triggered) {
			StartCoroutine(fadeButton());
			StartCoroutine(fadeText());
			play_triggered = true;
		}
	}

	IEnumerator fadeButton () {
		yield return new WaitForSeconds (START_DELAY);
		while(button_color.a < 1 ){
			button_color.a += FADE_RATE;
			play_button.color = button_color;
			yield return null;
		}
	}

	IEnumerator fadeText () {
		yield return new WaitForSeconds (START_DELAY);
		while(text_color.a < 1 ){
			text_color.a += FADE_RATE;
			play_text.color = text_color;
			yield return null;
		}
	}
}
