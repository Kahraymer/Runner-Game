using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public static int score;

//	public static bool lost = false;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = score.ToString ().PadLeft (4, '0');

//		if (lost) {
//			AudioSource.PlayClipAtPoint (gameOverSound, transform.position, 0.6f);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
