using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTextTrigger : MonoBehaviour {

	public GameObject helpText;
	public float visibleTime;

	private bool triggered = false;
	private float visibleTimer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			if (visibleTimer > visibleTime) {
				helpText.SetActive (true);
			} else {
				visibleTimer += Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (triggered == false && coll.gameObject.tag == "Player") {
			triggered = true;
			helpText.SetActive (false);
		}
	}
}
