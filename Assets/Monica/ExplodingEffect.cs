using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodingEffect : MonoBehaviour {
	public AudioClip explosionSound;

	private const float FINAL_X = 8f;
	private const float FINAL_Y = 5f;
	private const float FINAL_Z = 1f;
	private const float EXPLOSION_RATE = 0.1f;
	private bool explosion_triggered = false;
	private bool explosion_sound_played = false;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!explosion_triggered) {
			StartCoroutine(explosion());
			explosion_triggered = true;
		}
	}

	IEnumerator explosion() {
		for (int i = 5; i >= 1; i--) {
			transform.localScale = new Vector3 (FINAL_X/i,FINAL_Y/i,FINAL_Z/i);
			yield return new WaitForSeconds (EXPLOSION_RATE);

			if (!explosion_sound_played && (i <= Mathf.Ceil(explosionSound.length))) {
				AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1.0f);
				explosion_sound_played = true;
			}
		}
	}
}
