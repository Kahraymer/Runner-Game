using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {

	private float shakeTimer = 0.0f;
	private float duration = 1.0f;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (shakeTimer > 0.0) {
			float speed = 10;

			float strength = Mathf.Lerp (0, 8, shakeTimer / duration);
			transform.position = position + new Vector3(Mathf.PerlinNoise (shakeTimer*speed, 0f), Mathf.PerlinNoise (0f, shakeTimer*speed), 0) * strength;
			shakeTimer -= Time.deltaTime;
		} else {
			transform.position = position;
		}
	}

	public void Shake(float duration) {
		this.duration = duration;
		shakeTimer = duration;
	}
}
