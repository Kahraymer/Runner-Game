using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {
	public AudioClip hurtSound;
	public AudioClip lifeUpSound;

	public static int MAX_HEALTH = 3;

	[Tooltip("An array of objects that will be enabled and disabled to indicate current health.")]
	public Transform[] lifeIndicators;

	[Range(0, 3)]
	public int health;

	[Tooltip("After being hit, how long should the player be immune.")]
	public float immunityTime;

	private bool immune = false;
	private float immunityTimer = 0.0f;

	// Use this for initialization
	void Start () {
		if (lifeIndicators.Length != MAX_HEALTH)
			throw new UnityException ("Missing life indicators.");
	}

	// Update is called once per frame
	void Update () {
		if (immune) {
			GetComponent<SpriteRenderer> ().enabled = (immunityTimer % 0.5) > 0.25;

			immunityTimer += Time.deltaTime;
			if (immunityTimer > immunityTime) {
				immune = false;
				GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}

	void TakeDamage() {
		health--;
		immune = true;
		lifeIndicators [health].gameObject.SetActive (false);
		immunityTimer = 0.0f;

		if (health == 0) {
			FinalScore.score = GetComponent<ScoreKeeper> ().Score;
			SceneManager.LoadScene ("FinalScene");
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Obstacle" && !immune) {
			AudioSource.PlayClipAtPoint (hurtSound, transform.position);
			TakeDamage ();
		} else if (coll.gameObject.tag == "LifePickup") {
			if (health < 3) {
				++health;
				AudioSource.PlayClipAtPoint (lifeUpSound, transform.position);
				lifeIndicators [health - 1].gameObject.SetActive (true);
				Destroy (coll.gameObject);
			}
		}
	}
}
