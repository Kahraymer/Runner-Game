using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public LayerMask groundMask;

	public Transform groundCheck;

	public AudioClip jumpSound;

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

	public bool canDoubleJump;
	private bool secondJump = false;

	// These two variables detect if the player ever goes off-screen
	private float cameraHeight;
	private float cameraWidth;
	private Camera cam;

	// Use this for initialization
	void Start () {
		this.rigidBody = GetComponent<Rigidbody2D> ();

		cam = Camera.main;
		cameraHeight = 2f * cam.orthographicSize;
		cameraWidth = cameraHeight * cam.aspect;
	}

	private bool inverted = false;
	public bool Inverted {
		get { return inverted; }
		set { inverted = value; }
	}

	// Update is called once per frame
	void Update () {
		bool jump = Input.GetButtonDown ("Jump");
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			jump = true;
		}


		if (jumpPhase == JumpPhase.Grounded && (jump || rebound)) {
			rebound = false;
			secondJump = false;
			jumpPhase = JumpPhase.PreJump;
			AudioSource.PlayClipAtPoint (jumpSound, this.rigidBody.transform.position);
		} else if (canDoubleJump && !secondJump && jumpPhase != JumpPhase.Grounded && jump) {
			airTime = 0.0f; // Reset air-time.

			rebound = false;
			secondJump = true;
			jumpPhase = JumpPhase.PreJump;
		}

		if (jumpPhase == JumpPhase.Falling && jump) {
			rebound = true;
		}
			

		// Detects if player ever falls off screen. If so, kill him!
		if (transform.position.y < cam.transform.position.y - cameraHeight/2) {
			this.GetComponent<HealthManager> ().Kill ();
		}
	}

	void FixedUpdate() {
		float gravity = (-2 * maxJumpHeight) / (maxJumpTimeToApex * maxJumpTimeToApex);

		if (inverted)
			gravity *= -1;

		if (jumpPhase == JumpPhase.TerminatedRising) {
			gravity *= 3;
		}

		float jumpVelocity = (2 * maxJumpHeight) / maxJumpTimeToApex;

		rigidBody.AddForce (new Vector2(0, gravity) - Physics2D.gravity);

		if (jumpPhase == JumpPhase.Grounded) {
			airTime = 0.0f;
		} else {
			airTime += Time.fixedDeltaTime;
		}

		if (jumpPhase == JumpPhase.PreJump) {
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, inverted ? -jumpVelocity : jumpVelocity);
			jumpPhase = JumpPhase.Rising;
		}

		if (jumpPhase == JumpPhase.Rising) {
			bool letgo = Input.touchSupported ? Input.touchCount == 0 : !Input.GetButton ("Jump");
			if (airTime >= minJumpTime && letgo) {
				jumpPhase = JumpPhase.TerminatedRising;
			}
		}

		if (inverted ? rigidBody.velocity.y > 0 : rigidBody.velocity.y < 0) {
			jumpPhase = JumpPhase.Falling;
		}

		if (jumpPhase == JumpPhase.Falling) {
			if (groundCheck.GetComponent<Collider2D>().IsTouchingLayers(groundMask)) {
				jumpPhase = JumpPhase.Grounded;
			}
		}
	}
}