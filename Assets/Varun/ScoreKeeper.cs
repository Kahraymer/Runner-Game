using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Animations;

public class ScoreKeeper : MonoBehaviour {

	private GameObject scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText");
	}

	public void AddScore(int scoreToAdd) {
		score += scoreToAdd;
		scoreText.GetComponent<Text> ().text = score.ToString().PadLeft (4, '0');
		scoreText.GetComponent<Animator> ().SetTrigger("Pulse");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
