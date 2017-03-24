using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public Transform fireworks;

	public AudioClip endingJingle;

	public Transform fireworksArea;

	public float levelEndTime;

	private float levelEndTimer = 0.0f;
	private bool levelEnded = false;

	public float fireworkTime;
	private float fireworkTimer = 0.0f;

	public bool LevelEnded {
		get { return levelEnded; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (levelEnded) {
			levelEndTimer += Time.deltaTime;
			fireworkTimer += Time.deltaTime;

			if (levelEndTimer > levelEndTime) {
				SceneManager.LoadScene ("FinalSceneWin");
			}

			if (fireworkTimer > fireworkTime) {
				SpawnFirework ();
				fireworkTimer = 0.0f;
			}
		}
	}

	void SpawnFirework() {
		Bounds bounds = fireworksArea.GetComponent<BoxCollider2D> ().bounds;
		Vector3 position = bounds.min + new Vector3 (Random.value * bounds.size.x, Random.value * bounds.size.y, Random.value * bounds.size.z);
		Instantiate (fireworks, position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !levelEnded) {
			levelEnded = true;
			SpawnFirework ();
			AudioSource.PlayClipAtPoint (endingJingle, transform.position);

		}
	}
}
