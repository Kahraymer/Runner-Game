using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour {

	float letterTime = 0.1f;
	string title;
	Text screenTitle;

	// Use this for initialization
	void Start () {
		screenTitle = GetComponent<Text>();
		title += screenTitle.text;
		screenTitle.text = "";
		StartCoroutine(animateText());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator animateText() {
		foreach (char letter in title.ToCharArray()) {
			//finalTitle += letter;
			screenTitle.text += letter;
			yield return new WaitForSeconds (letterTime);
		}
	}
}
