using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectdropper : MonoBehaviour {
	public GameObject toBeDropped;
	private GameObject pc;
//	public int height = this.transform.position.y;
	bool dropped = false;

	// Use this for initialization
	void Start () {
		pc = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x - pc.transform.position.x <= 11 && dropped == false) {
			
			Vector3 location = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
			GameObject newthing = Instantiate (toBeDropped, location, Quaternion.identity);
			//newthing.rigidbody2D.gravityScale *= 2;
			//newthing.GetComponent<rigidbody2D>() = 4;
			dropped = true;
		}
	}
}
