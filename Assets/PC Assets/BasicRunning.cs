using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRunning : MonoBehaviour {

    public float startingSpeed = 5;
    public Rigidbody2D pcRigidbody2D;
    //public Rigidbody2D 
  

	// Use this for initialization
	void Start () {
        // Continue to run to the right.
        pcRigidbody2D = GetComponent<Rigidbody2D>();

        
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * startingSpeed, ForceMode2D.Force);
		
	}
	
	// Update is called once per frame
	void Update () {
        // transform.Translate(startingSpeed * Time.deltaTime, 0f, 0f);

		// TODO: Is this making a new velocity vector every time? 
        pcRigidbody2D.velocity = new Vector2(startingSpeed, pcRigidbody2D.velocity.y);

    }
}
