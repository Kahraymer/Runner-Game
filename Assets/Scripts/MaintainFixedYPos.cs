using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainFixedYPos : MonoBehaviour {

	private float yPos;
	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent;
		yPos = transform.position.y;
		transform.SetParent (null);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (parent.position.x, yPos, parent.position.z);
	}
}
