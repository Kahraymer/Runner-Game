using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform groundCheckTopLeft;
	public Transform groundCheckBottomRight;
	public LayerMask groundMask;
	public float runSpeed;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		bool grounded = Physics2D.OverlapArea (groundCheckTopLeft.position, groundCheckBottomRight.position, groundMask);
		rigidBody.velocity = new Vector2 (runSpeed, rigidBody.velocity.y);

		if (grounded && Input.GetAxis("Jump") > 0) {
			this.rigidBody.AddForce (new Vector2(0, 100));
		}
	}
}
