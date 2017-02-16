using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToComic : MonoBehaviour {

	//var levelToLoad;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Next")) {
			 SceneManager.LoadScene ("Tom/Tutorial", LoadSceneMode.Single);
		}
	}
}
