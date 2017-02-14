using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBase : MonoBehaviour {

	// Struct for objects and their spawn locations
	public struct WorldEntry {
		public Vector3 loc;		// (x,y,z) of object location
		public GameObject obj;	// The GameObject itself
		public float offset; 	// Possibly unnecessary, optimizes for ints
	}

	private List<WorldEntry> levelObjects; // = new List<WorldEntry> ();
	private GameObject pc;
	private int spawningOffset;


	// Use this for initialization
	public void Start () {

	}


	public void WorldStart (List<WorldEntry> level) {
		spawningOffset = 16;
		pc = GameObject.FindGameObjectWithTag ("Player");
		levelObjects = level;


		// Instantiate everything that should be on screen or will be soon
		while (levelObjects.Count > 0) {
			WorldEntry thisentry = levelObjects [0];
			if (thisentry.loc.x < spawningOffset) {
//				Debug.Log ("Instantiate! at " + thisentry.loc.x);
				Instantiate (thisentry.obj, thisentry.loc, Quaternion.identity);
				levelObjects.RemoveAt (0);
			} else {
				break;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		WorldUpdate ();
	}

	public void WorldUpdate () {
		Vector3 pcPos = pc.transform.position;
		// TODO: Make pcPos ints, not floats ?


		// Instantiate anything that is going to be on screen soon
		while (levelObjects.Count > 0) {
			WorldEntry thisentry = levelObjects [0];
			if (thisentry.loc.x < pcPos.x + spawningOffset) {
//				Debug.Log ("Instantiate! at " + thisentry.loc.x);
				Instantiate (thisentry.obj, thisentry.loc, Quaternion.identity);
				levelObjects.RemoveAt (0);
			} else {
				break;
			}
		}
			
	}
}
