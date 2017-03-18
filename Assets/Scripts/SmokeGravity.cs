using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGravity : MonoBehaviour {

	private PlayerController controller;
	private ParticleSystem particles;
	private float gravity;

	// Use this for initialization
	void Start () {
		controller = GetComponentInParent<PlayerController> ();
		particles = GetComponent<ParticleSystem> ();
		gravity = particles.main.gravityModifier.constant;
	}
	
	// Update is called once per frame
	void Update () {
		ParticleSystem.MainModule main = particles.main;
		if (controller.Inverted) {
			main.gravityModifier = new ParticleSystem.MinMaxCurve(-gravity);
		} else {
			main.gravityModifier = new ParticleSystem.MinMaxCurve(gravity);
		}
	}
}
