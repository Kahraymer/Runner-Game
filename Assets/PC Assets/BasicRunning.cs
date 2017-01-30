using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRunning : MonoBehaviour {

    public float runningVelocity = 3;
   // public float fallingVelocity = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(runningVelocity * Time.deltaTime, 0f, 0f);
    }
}
