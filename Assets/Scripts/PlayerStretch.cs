using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStretch : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		initialScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		bool inverted = GetComponent<PlayerController> ().Inverted;
		float targetScale = 1.0f - 0.3f * Mathf.Clamp (inverted ? -rigidbody.velocity.y : rigidbody.velocity.y, 0.0f, 20.0f) / 20.0f;
		transform.localScale = new Vector3 (initialScale.x * targetScale , transform.localScale.y, transform.localScale.z);
	}
}
