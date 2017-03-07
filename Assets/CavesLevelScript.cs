using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavesLevelScript : MonoBehaviour {

	public GameObject ground;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Copy-paste these three lines at the beginning of your level's Start() function
		WorldBase wb = GetComponent<WorldBase> ();
		wb.levelObjects = new List<WorldBase.WorldEntry> ();
		wb.backgroundObjects = new List<WorldBase.WorldEntry> ();
	}
}
