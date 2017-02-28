using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	private Vector3 position;
	private Rigidbody2D obstacle_rigid_body;
//	private ground_level
	public float speed = 5;
	public AudioClip bumpSound;


	// Use this for initialization
	void Start () {
		obstacle_rigid_body = GetComponent<Rigidbody2D> ();
		obstacle_rigid_body.velocity = new Vector2 (0, -speed);
//		ground_level = GameObject.FindGameObjectWithTag("Respawn");
//		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		if (transform.position.y - GetComponent<BoxCollider2d> ().size.height/2 <= 
		obstacle_rigid_body.velocity = new Vector2 (0, obstacle_rigid_body.velocity.y);
//		transform.position = new Vector3 (position.x, position.y - (speed * Time.deltaTime), 0);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ground") {
			obstacle_rigid_body.velocity = new Vector2 (0, -1 * obstacle_rigid_body.velocity.y);
			AudioSource.PlayClipAtPoint (bumpSound, coll.transform.position);
		}
	}
}
