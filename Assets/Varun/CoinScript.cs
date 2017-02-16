using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public AudioClip coinCollectionSound;

	[Tooltip("An explosion or other particle effect to spawn at the coin when it is collected.")]
	public Transform explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			AudioSource.PlayClipAtPoint (coinCollectionSound, coll.transform.position);
			GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreKeeper> ().AddScore (5);
			Instantiate (explosion, transform.position, Quaternion.identity);
		}
	}
}
