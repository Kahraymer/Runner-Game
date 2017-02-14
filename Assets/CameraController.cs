using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public GameObject frame;

	private Vector3 offset;
	private int zoomout = 10;

	// Use this for initialization
	void Start () {
		frame.transform.position = player.transform.position + new Vector3 (6, 4, -zoomout);
		offset = transform.position + player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		// If you want the camera to follow jumps, use the line below:
		// transform.position = player.transform.position + offset;

		// If you don't want the camera to follow jumps, use the line below instead:
		frame.transform.position = new Vector3 (player.transform.position.x, 0, 0) + offset;
	}
}
