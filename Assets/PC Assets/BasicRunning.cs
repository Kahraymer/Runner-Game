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
       // pcRigidbody2D = GetComponent<Rigidbody2D>();
//		pcRigidbody2D.velocity = new Vector2(startingSpeed, pcRigidbody2D.velocity.y); 
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * startingSpeed, ForceMode2D.Force);
		
	}
	
	// Update is called once per frame
	void Update () {
       // transform.Translate(startingSpeed * Time.deltaTime, 0f, 0f);
//		float xpos = transform.position.x;
//		transform.position.x = (xpos + startingSpeed);
		Vector3 change = new Vector3(startingSpeed, 0, 0);
		//transform.position = new Vector3 (transform.position.x + startingSpeed, transform.position.y, transform.position.z);
		transform.position += change;
		// TODO: Is this making a new velocity vector every time? 
//		pcRigidbody2D.velocity = new Vector2(startingSpeed, pcRigidbody2D.velocity.y); 
		//transform.Translate(5f * Time.deltaTime, 0f, 0f);
	}
}
