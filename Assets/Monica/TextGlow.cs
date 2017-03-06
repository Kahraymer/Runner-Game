using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGlow : MonoBehaviour {

	// Text glow variables
	private Text play_text;
	private Shadow text_shadow;
	private Color text_shadow_color;
	private bool effectStarted = false;
	private bool glow = true; // Oscillates the shadow alpha value


	// Use this for initialization
	void Start () {
		play_text = GetComponentInChildren<Text>();
		text_shadow = play_text.GetComponent<Shadow>();

		// Initialize shadow effect
		text_shadow_color = text_shadow.effectColor;
		text_shadow_color.a = 0;
		text_shadow.effectColor = text_shadow_color;
	}

	// Update is called once per frame
	void Update () {
		if (!effectStarted && (play_text.color.a > .8f)) { // Wait until the original text is mostly faded in
			effectStarted = true;
		}

		if (effectStarted) {
			if (glow) {
				text_shadow_color.a += .02f;
				text_shadow.effectColor = text_shadow_color;
				if (text_shadow_color.a >= .8f) {
					glow = false;
				}
			} else {
				text_shadow_color.a -= .02f;
				text_shadow.effectColor = text_shadow_color;
				if (text_shadow_color.a <= .2f) {
					glow = true;
				}
			}
		}
	}
}
