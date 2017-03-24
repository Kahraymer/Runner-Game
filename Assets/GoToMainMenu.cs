using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Go() {
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);
		GameObject menuMusic = GameObject.FindGameObjectWithTag ("MenuMusic");
		if (menuMusic) {
			Destroy (menuMusic);
		}
	}
}
