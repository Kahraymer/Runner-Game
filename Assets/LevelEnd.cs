using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public float levelEndTime;

	private float levelEndTimer = 0.0f;
	private bool levelEnded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (levelEnded) {
			levelEndTimer += Time.deltaTime;
			if (levelEndTimer > levelEndTime) {
				SceneManager.LoadScene ("FinalScene");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !levelEnded) {
			levelEnded = true;
		}
	}
}
