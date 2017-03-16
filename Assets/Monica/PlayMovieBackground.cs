using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovieBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//((MovieTexture)GetComponent<RawImage>().texture).Play();
		MovieTexture bg = ((MovieTexture) GetComponent<RawImage> ().texture);
		bg.Play ();
		bg.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
