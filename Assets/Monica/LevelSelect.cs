using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	bool cityTransition = false;
	bool caveTransition = false;
	bool factoryTransition = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(cityTransition) {
			SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
		}

		if(caveTransition) {
			SceneManager.LoadScene ("Varun/Caves", LoadSceneMode.Single);
		}

		if(factoryTransition) {
			SceneManager.LoadScene ("Matthew/factory", LoadSceneMode.Single);
		}
		
	}

	public void cityLevelClicked() {
		cityTransition = true;
	}

	public void caveLevelClicked() {
		caveTransition = true;
	}

	public void factoryLevelClicked() {
		factoryTransition = true;
	}
}
