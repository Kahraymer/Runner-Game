using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
	public float speed;
	private LevelEnd levelEnd;

	// Use this for initialization
	void Start () {
		GameObject end = GameObject.FindGameObjectWithTag ("LevelEnd");
		if (end != null)
			levelEnd = end.GetComponent<LevelEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelEnd != null && levelEnd.LevelEnded)
			return;
		transform.localPosition += Time.deltaTime * speed * new Vector3 (1, 0, 0);
	}
}
