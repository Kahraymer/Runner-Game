using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayiing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
//		GameObject gameMusic = GameObject.FindGameObjectWithTag ("LevelMusic");
//		if (gameMusic) {
//			Destroy (gameMusic);
//		}

		DontDestroyOnLoad(transform.gameObject);
	}
}
