using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour {
	public AudioClip landingSound;

	private const float START_DELAY = 1.5f; // This is approx. the length of the first explosion animation
	private const float LANDING_RATE = 0.1f;
	private const float INIT_XY = 20f;
	private const float FINAL_XY = 1f;
	private const float Z = 1f;
	private bool text_triggered = false;

	private Text txt;
	private Color txt_color;
		

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0,0,0); // Not initially visible on the screen
//		txt = GetComponent<Text>();
//		Color bottomColor = Color.red;
//		Color topColor = Color.black;
//		Color gradient = Color32.Lerp(bottomColor, topColor, .7f);
//		txt.color = gradient;
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
		AudioSource.PlayClipAtPoint(landingSound, transform.position, 1.0f);
	}
}
