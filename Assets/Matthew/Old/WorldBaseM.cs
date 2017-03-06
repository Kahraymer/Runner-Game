using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBaseM: MonoBehaviour {

	// Struct for objects and their spawn locations
	public struct WorldEntry {
		public Vector3 loc;		// (x,y,z) of object location
		public GameObject obj;	// The GameObject itself
	}

    public WorldEntry makeWorldEntry (Vector3 loc, GameObject obj) {
        WorldEntry entry = new WorldEntry();
        entry.loc = loc;
        entry.obj = obj;
        return entry;
    }

	public List<WorldEntry> levelObjects = new List<WorldEntry> ();
    private int spawningOffset = 18;
	public GameObject pc;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void WorldUpdate () {
		Vector3 pcPos = pc.transform.position;

		foreach (WorldEntry entry in levelObjects) {
			if (entry.loc.x < pcPos.x + spawningOffset) {
				GameObject myObj = Instantiate (entry.obj, entry.loc, Quaternion.identity);
				Debug.Log ("Instantiated an object");
				levelObjects.Remove (entry);
			}
		}


	}
}
