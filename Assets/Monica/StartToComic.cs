using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartToComic : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		bool transitionScene = (Input.GetButtonDown("Start") || Input.GetButtonDown("Next"));
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			transitionScene = true;
		}

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
}
