using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonicaWorldBase : MonoBehaviour {

	// Struct for objects and their spawn locations
	public struct MonicaWorldEntry {
		public Vector3 loc;		// (x,y,z) of object location
		public GameObject obj;	// The GameObject itself
		public float offset; 	// Possibly unnecessary, optimizes for ints
	}

	private List<MonicaWorldEntry> levelObjects; // = new List<MonicaWorldEntry> ();
	public GameObject mpc;
	private int spawningOffset;


	// Use this for initialization
	public void Start () {

	}


	public void MonicaWorldStart (List<MonicaWorldEntry> level) {
		spawningOffset = 15;

		levelObjects = level;


		// Instantiate everything that should be on screen or will be soon
		while (levelObjects.Count > 0) {
			MonicaWorldEntry thisentry = levelObjects [0];
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
		MonicaWorldUpdate ();
	}

	public void MonicaWorldUpdate () {
		Vector3 pcPos = mpc.transform.position;
		// TODO: Make pcPos ints, not floats ?


		// Instantiate anything that is going to be on screen soon
		while (levelObjects.Count > 0) {
			MonicaWorldEntry thisentry = levelObjects [0];
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
