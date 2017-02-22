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

	public List<WorldEntry> levelObjects;
	public List<WorldEntry> backgroundObjects;
	public GameObject pc;
	private int spawningOffset;


	// Use this for initialization
	public void Start () {
	}


	public void WorldStart () {
		// Sorting level by x position
		levelObjects.Sort ((x, y) => x.loc.x.CompareTo (y.loc.x));

		spawningOffset = 18;
//		pc = GameObject.FindGameObjectWithTag ("Player");
//		levelObjects = level;

		Vector3 pcpos = pc.transform.position;
		// Actual starting position
		pc.transform.position = new Vector3 (pcpos.x, pcpos.y + 10, pcpos.z); 

		// Testing starting position
//		pc.transform.position = new Vector3 (pcpos.x + 420, pcpos.y, pcpos.z);

		// Instantiate all the background panels, so that they'll be layered correctly
//		foreach (WorldEntry bg in backgroundObjects) {
//			Instantiate (bg.obj, bg.loc, Quaternion.identity);
//		}


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

	public void AddObjects (List<float> x_locs, List<float> y_locs, GameObject obj) {
		for (int i = 0; i < x_locs.Count; i++) {
			AddObject (x_locs [i], y_locs [i], obj);
		}
	}

	public void AddObjects (Dictionary<float, float> locs, GameObject obj) {
		foreach (var elem in locs) {
			AddObject (elem.Key, elem.Value, obj);
		}
	}

	public void AddObject (float x, float y, GameObject obj) {
		WorldBase.WorldEntry entry = new WorldBase.WorldEntry ();
		entry.obj = obj;
		entry.loc = new Vector3 (x, y, 0);
		levelObjects.Add (entry);
	}

	public void AddBackground (float x, float y, GameObject bg) {
		WorldBase.WorldEntry entry = new WorldBase.WorldEntry ();
		entry.obj = bg;
		entry.loc = new Vector3 (x, y, 0);
		backgroundObjects.Add (entry);
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
