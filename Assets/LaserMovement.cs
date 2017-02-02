using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

	public float laserSpeed;
	public AudioClip laserShootSound;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (laserShootSound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Time.deltaTime * new Vector3 (laserSpeed, 0, 0);
	}
}
