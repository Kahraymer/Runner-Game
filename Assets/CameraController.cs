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
		transform.position = player.transform.position + offset;
	}
}
