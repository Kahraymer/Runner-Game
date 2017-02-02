using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform groundCheckTopLeft;
	public Transform groundCheckBottomRight;
	public LayerMask groundMask;

	[Tooltip("The height of a max jump.")]
	public float maxJumpHeight;

	[Tooltip("The time to apex of a max jump.")]
	public float maxJumpTimeToApex;

	[Tooltip("The minimum amount of time before a jump can be terminated.")]
	public float minJumpTime;

	private Rigidbody2D rigidBody;

	/// <summary>
	/// This field tracks the amount of time the player has spent in air. Should be equal to 0 if the player is grounded.
	/// </summary>
	private float airTime = 0.0f;

	private enum JumpPhase { Grounded, PreJump, Rising, TerminatedRising, Falling }
	private JumpPhase jumpPhase = JumpPhase.Grounded;

	private bool rebound = false;

	// Use this for initialization
	void Start () {
		this.rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (jumpPhase == JumpPhase.Grounded && (Input.GetButtonDown ("Jump") || rebound)) {
			rebound = false;
			jumpPhase = JumpPhase.PreJump;
		}

		if (jumpPhase == JumpPhase.Falling && Input.GetButtonDown ("Jump")) {
			rebound = true;
		}
	}

	void FixedUpdate() {
		float gravity = (-2 * maxJumpHeight) / (maxJumpTimeToApex * maxJumpTimeToApex);
		if (jumpPhase == JumpPhase.TerminatedRising) {
			gravity *= 3;
		}

		float jumpVelocity = (2 * maxJumpHeight) / maxJumpTimeToApex;

		rigidBody.AddForce (new Vector2(0, gravity));

		if (jumpPhase == JumpPhase.Grounded) {
			airTime = 0.0f;
		} else {
			airTime += Time.fixedDeltaTime;
		}

		if (jumpPhase == JumpPhase.PreJump) {
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpVelocity);
			jumpPhase = JumpPhase.Rising;
		}

		if (jumpPhase == JumpPhase.Rising) {
			if (airTime >= minJumpTime && !Input.GetButton("Jump")) {
				jumpPhase = JumpPhase.TerminatedRising;
			}
		}

		if (rigidBody.velocity.y < 0) {
			jumpPhase = JumpPhase.Falling;
		}

		if (jumpPhase == JumpPhase.Falling) {
			if (Physics2D.OverlapArea (groundCheckTopLeft.position, groundCheckBottomRight.position, groundMask)) {
				jumpPhase = JumpPhase.Grounded;
			}
		}
	}
}