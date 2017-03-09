using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public static int score;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = score.ToString ().PadLeft (4, '0');
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
