using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public Transform scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void AddScore(int scoreToAdd) {
		score += scoreToAdd;
		scoreText.GetComponent<Text> ().text = score.ToString().PadLeft (4, '0');
	}
	
	// Update is called once per frame
	void Update () {
	}
}
