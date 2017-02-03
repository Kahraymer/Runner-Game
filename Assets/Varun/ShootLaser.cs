using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour {

	public Transform laser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Shoot")) {
			Instantiate (laser, transform.position, Quaternion.identity);
		}
	}
}
