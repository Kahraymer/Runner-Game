using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartToComic : MonoBehaviour {

	public AudioClip buttonPushSound;

	bool transitionScene;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		// Keyboard functionality
		if (transitionScene && (SceneManager.GetActiveScene ().name == "Start")) {
			SceneManager.LoadScene ("ComicOne", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

		if (transitionScene && (SceneManager.GetActiveScene ().name == "ComicOne")) {
			SceneManager.LoadScene ("ComicTwo", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

		if (transitionScene && (SceneManager.GetActiveScene ().name == "ComicTwo")) {
			SceneManager.LoadScene ("ComicThree", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

		if (transitionScene && (SceneManager.GetActiveScene ().name == "ComicThree")) {
			SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

	/*	if (transitionScene && (SceneManager.GetActiveScene ().name == "ComicFour")) {
			SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}*/

		if (transitionScene && (SceneManager.GetActiveScene ().name == "FinalScene")) {
			SceneManager.LoadScene ("WorldSelector", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

		if (transitionScene && (SceneManager.GetActiveScene ().name == "FinalSceneWin")) {
			SceneManager.LoadScene ("WorldSelector", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}

		if (transitionScene && (SceneManager.GetActiveScene ().name == "Credits")) {
			SceneManager.LoadScene ("WorldSelector", LoadSceneMode.Single);
			AudioSource.PlayClipAtPoint (buttonPushSound, transform.position, 1.0f);
		}
	}

	public void nextClicked() {
		transitionScene = true;
	}

}
