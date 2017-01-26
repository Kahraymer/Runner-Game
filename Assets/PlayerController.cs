using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform groundCheckTopLeft;
	public Transform groundCheckBottomRight;
	public LayerMask groundMask;

	public float runSpeed;
	public float minJumpForceTime;
	public float maxJumpForceTime;

	// The amount of force to apply to the player when jumping.
	public float jumpVelocity;

	private Rigidbody2D rigidBody;

	/// <summary>
	/// This field tracks the amount of time the player has spent in air. Should be equal to 0 if the player is grounded.
	/// </summary>
	private float airTime = 0.0f;

	private bool grounded = false;
	private bool jumping = false;
	private bool rebound = true;

	private bool terminatedJump = false;

	// Use this for initialization
	void Start () {
		this.rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		// Continue to run to the right.
		rigidBody.velocity = new Vector2 (runSpeed, rigidBody.velocity.y);

		// Check if the player is grounded.
		grounded = Physics2D.OverlapArea (groundCheckTopLeft.position, groundCheckBottomRight.position, groundMask);


		if (!grounded && rigidBody.velocity.y < 0 && Input.GetButtonDown ("Jump")) {
			rebound = true;
		}

		if (!jumping) {
			if (grounded && (Input.GetButtonDown ("Jump") || rebound)) {
				jumping = true;
				rebound = false;
				terminatedJump = false;
			}
		}

		if (jumping) {
			// If the airtime is greater than 0, but we are now grounded then the jump has ended.
			if (airTime > 0.0f && grounded)
				jumping = false;
			
			if (airTime < minJumpForceTime) {
				rigidBody.velocity = new Vector2(0, jumpVelocity);
				if (!Input.GetButton ("Jump"))
					terminatedJump = true;
 			}

			if (airTime < maxJumpForceTime && !terminatedJump) {
				rigidBody.velocity = new Vector2(0, jumpVelocity);
			}
		}

		// Update the air timer depending on whether or not the player is grounded.
		if (grounded)
			airTime = 0.0f;
		else
			airTime += Time.fixedDeltaTime;
	}
}