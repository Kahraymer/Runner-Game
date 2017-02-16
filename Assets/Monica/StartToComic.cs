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
		if(Input.GetButton("Start") && (SceneManager.GetActiveScene().name == "Start")) {
			 SceneManager.LoadScene ("ComicOne", LoadSceneMode.Single);
		}

		if(Input.GetButton("Next") && (SceneManager.GetActiveScene().name == "ComicOne")) {
			 SceneManager.LoadScene ("ComicTwo", LoadSceneMode.Single);
		}

		if(Input.GetButton("Next") && (SceneManager.GetActiveScene().name == "ComicTwo")) {
			 SceneManager.LoadScene ("ComicThree", LoadSceneMode.Single);
		}

		if(Input.GetButton("Next") && (SceneManager.GetActiveScene().name == "ComicThree")) {
			 SceneManager.LoadScene ("ComicFour", LoadSceneMode.Single);
		}

		if(Input.GetButton("Next") && (SceneManager.GetActiveScene().name == "ComicFour")) {
			 SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
		}
	}
}
