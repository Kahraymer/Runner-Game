using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour {
	public AudioClip landingSound;

	private const float START_DELAY = 1.5f; // This is approx. the length of the first explosion animation
	private const float ANIMATION_LENGTH = 0.5f;
	private const float INIT_XY = 20f;
	private const float FINAL_XY = 1f;
	private const float Z = 1f;
	private bool text_triggered = false;

	private Text txt;
	private Color txt_color;
		

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

		float animationStart = Time.time;
		while (Time.time < animationStart + ANIMATION_LENGTH) {
			float scale = Mathf.Lerp (INIT_XY, FINAL_XY, (Time.time - animationStart)/ANIMATION_LENGTH);
			transform.localScale = new Vector3 (scale, scale,Z);
			yield return new WaitForEndOfFrame ();
		}
		Camera.main.SendMessage ("Shake", 0.5f);
		transform.localScale = new Vector3 (FINAL_XY,FINAL_XY,Z);
		AudioSource.PlayClipAtPoint(landingSound, transform.position, 1.0f);
	}
}
