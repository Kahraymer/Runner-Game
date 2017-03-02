using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_rotator : MonoBehaviour {

	//private GameObject gear;

	// Use this for initialization
	void Start () {
		//gear = this.GetComponent (transform);
	}
	
	// Update is called once per frame
	void Update () {
	//	gear.Rotate (0, 0, Time.deltaTime, Space.World);
		this.transform.Rotate(Vector3.forward * -1);
	}
}
