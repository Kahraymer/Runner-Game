using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	private Rigidbody2D obstacle_rigid_body;
	public float speed = 5;
	public AudioClip bumpSound;


	// Use this for initialization
	void Start () {
		obstacle_rigid_body = GetComponent<Rigidbody2D> ();
		obstacle_rigid_body.velocity = new Vector2 (0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		obstacle_rigid_body.velocity = new Vector2 (0, obstacle_rigid_body.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ground") {
			obstacle_rigid_body.velocity = new Vector2 (0, -1 * obstacle_rigid_body.velocity.y);
			AudioSource.PlayClipAtPoint (bumpSound, coll.transform.position);
		}
	}
}
