using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransitionFade : MonoBehaviour {
	private float fadeTimer = 1.0f;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		image.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeTimer > 0.0f) {
			fadeTimer -= Time.deltaTime;
			image.color = new Color (1.0f, 1.0f, 1.0f, fadeTimer);
		} else {
			Destroy (this.gameObject);
		}
	}
}
