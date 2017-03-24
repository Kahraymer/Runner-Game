using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	private GameObject scoreText;

	private int score = 0;
	public int Score {
		get { return score; }
	}

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText");
	}

	public void AddScore(int scoreToAdd) {
		score += scoreToAdd;
		scoreText.GetComponent<Text> ().text = score.ToString().PadLeft (4, '0');
		scoreText.GetComponent<Animator> ().SetTrigger("Pulse");
		FinalScore.score = score;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
