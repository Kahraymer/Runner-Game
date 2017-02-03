using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public AudioClip coinCollectionSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Coin") {
			Destroy (coll.gameObject);
			AudioSource.PlayClipAtPoint (coinCollectionSound, coll.transform.position);
		}
	}
}
