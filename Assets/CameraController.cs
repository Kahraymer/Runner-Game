using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public GameObject background;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position + new Vector3(background.transform.position.x, -background.transform.position.y*3/4,background.transform.position.z) + player.transform.position/2;
	}

	// Update is called once per frame
	void LateUpdate () {
		// If you want the camera to follow jumps, use the line below:
		// transform.position = player.transform.position + offset;

		// If you don't want the camera to follow jumps, use the line below instead:
		transform.position = new Vector3 (player.transform.position.x, 0, 0) + offset;
	}
}
