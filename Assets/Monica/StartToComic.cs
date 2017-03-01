using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartToComic : MonoBehaviour {

	bool transitionScene;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// Keyboard functionality
		if(transitionScene && (SceneManager.GetActiveScene().name == "Start")) {
			 SceneManager.LoadScene ("ComicOne", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "ComicOne")) {
			 SceneManager.LoadScene ("ComicTwo", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "ComicTwo")) {
			 SceneManager.LoadScene ("ComicThree", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "ComicThree")) {
			 SceneManager.LoadScene ("ComicFour", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "ComicFour")) {
			 SceneManager.LoadScene ("SecondStart", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "SecondStart")) {
			 SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
		}

		if(transitionScene && (SceneManager.GetActiveScene().name == "FinalScene")) {
			 SceneManager.LoadScene ("SecondStart", LoadSceneMode.Single);
		}
	}

	public void nextClicked() {
		transitionScene = true;
	}

}
