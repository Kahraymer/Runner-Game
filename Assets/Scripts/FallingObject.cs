using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {
	[Tooltip("The object will start to fall when it is this far from the player.")]
	public float triggerDistance;

	[Tooltip("The object will accelerate at this speed when falling.")]
	public float fallAcceleration;

	[Tooltip("The object will stop moving once it reaches this offset.")]
	public float fallDistance;

	private bool falling = false;
	private float fallTime = 0.0f;
	private GameObject player;
	private Vector3 initalPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		initalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < triggerDistance) {
			falling = true;
		}

		if (falling) {
			fallTime += Time.deltaTime;
			float offset = (fallAcceleration * fallTime * fallTime) / 2.0f;
			if (Mathf.Abs (offset) < fallDistance) {
				transform.position = initalPosition + new Vector3 (0, offset, 0);
			} else {
				transform.position = initalPosition + new Vector3 (0, Mathf.Sign(offset) * fallDistance, 0);
				Destroy (this);
			}
		}
	}
}
