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

	public Sprite noDamage;
	public Sprite lightDamage;
	public Sprite heavyDamage;

	private static Color visible = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	private static Color invisible = new Color(1.0f, 1.0f, 1.0f, 0.2f);

	// Update is called once per frame
	void Update () {
		if (immune) {
			GetComponentInChildren<SpriteRenderer> ().color = ((immunityTimer % 0.5) > 0.25) ? visible : invisible;

			immunityTimer += Time.deltaTime;
			if (immunityTimer > immunityTime) {
				immune = false;
				GetComponentInChildren<SpriteRenderer> ().color = visible;
			}
		}
	}

	public Transform spark;

	void TakeDamage() {
		spark.GetComponent<ParticleSystem> ().Play ();

		health--;
		immune = true;
		lifeIndicators [health].gameObject.SetActive (false);
		immunityTimer = 0.0f;
		UpdateSprite ();

		if (health == 0) {
			Kill ();
		}
	}

	public Transform smoke;

	public void UpdateSprite() {
		switch (health) {
		case 3:
			GetComponentInChildren<SpriteRenderer> ().sprite = noDamage;
			break;
		case 2:
			GetComponentInChildren<SpriteRenderer> ().sprite = lightDamage;
			break;
		case 1:
			GetComponentInChildren<SpriteRenderer> ().sprite = heavyDamage;
			break;
		}

		if (health == 1) {
			smoke.GetComponent<ParticleSystem> ().Play ();
		} else {
			smoke.GetComponent<ParticleSystem> ().Stop ();
		}
	}

	public void Kill () {
//		AudioSource.PlayClipAtPoint (gameOverSound, transform.position);
		FinalScore.score = GetComponent<ScoreKeeper> ().Score;
		SceneManager.LoadScene ("FinalScene");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Obstacle" && !immune) {
			AudioSource.PlayClipAtPoint (hurtSound, transform.position);
			TakeDamage ();
		} else if (coll.gameObject.tag == "LifePickup") {
			if (health < 3) {
				++health;
				lifeIndicators [health - 1].gameObject.SetActive (true);
				UpdateSprite ();
			}

			// Destroy the power-up, even if at max health.
			AudioSource.PlayClipAtPoint (lifeUpSound, transform.position);
			Destroy (coll.gameObject);

			// Add some score for picking up the life.
			GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreKeeper> ().AddScore (5);
		}
	}
}
