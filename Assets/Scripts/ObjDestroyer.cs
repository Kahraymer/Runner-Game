using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyer : MonoBehaviour {

    private GameObject pc;
    private int outOfFrameOffset = 38;

	// Use this for initialization
	void Start () {
        pc = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= pc.transform.position.x - outOfFrameOffset) {
            Destroy(this.gameObject, 0);
        }
	}
}
