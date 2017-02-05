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

	public List<WorldEntry> levelObjects = new List<WorldEntry> ();
	private int spawningOffset;

	// The following two objects should eventually be in the level script
	public GameObject pc;
	public GameObject ground;

	// Use this for initialization
	void Start () {
		spawningOffset = 15;
		WorldStart ();
	}


	public void WorldStart () {

		// The following for-loop (i.e. level construction) should be done in the level script
		for (int i = 0; i < 5; i++) {
			WorldEntry entry = new WorldEntry ();

			float blockWidth = ground.GetComponent<BoxCollider2D> ().bounds.size.x;

			entry.loc = new Vector3 (4 + i*blockWidth, 0, 0);
			entry.obj = ground;
			levelObjects.Add (entry);
		}



		// This for-loop is in the right spot :)
		for (int i = 0; i < levelObjects.Count; i++) {
			WorldEntry thisentry = levelObjects[i];

			// If the object is supposed to be in the first screen, instantiate it.
			if (thisentry.loc.x < spawningOffset) {
				Debug.Log ("Instantiate!");
				GameObject myObj = Instantiate (thisentry.obj, thisentry.loc, Quaternion.identity);
				levelObjects.RemoveAt (i);
				i -= 1;
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

		foreach (WorldEntry entry in levelObjects) {
			if (entry.loc.x < pcPos.x + spawningOffset) {
				GameObject myObj = Instantiate (entry.obj, entry.loc, Quaternion.identity);
				levelObjects.Remove (entry);
			}
		}


	}
}
