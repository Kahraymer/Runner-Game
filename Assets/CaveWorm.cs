using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWorm : MonoBehaviour {

	private Vector3 position;
	private Vector3 target;

	private bool triggered = false;

	public Vector3 offset;

	public float animationTime = 1.0f;
	private float animationTimer = 0.0f;

	// Use this for initialization
	void Start () {
		position = transform.position;
		target = transform.position + offset;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			if (animationTimer < animationTime) {
				transform.position = Vector3.Lerp (position, target, animationTimer / animationTime);
				animationTimer += Time.deltaTime;
			} else {
				transform.position = target;
			}
		}
	}

	public void PopOutOfGround() {
		triggered = true;
	}
}
