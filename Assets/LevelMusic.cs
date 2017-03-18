using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Awake() {
		GameObject menuMusic = GameObject.FindGameObjectWithTag ("MenuMusic");
		if (menuMusic) {
			Destroy (menuMusic);
		}
//
//		DontDestroyOnLoad(transform.gameObject);
	}
}
