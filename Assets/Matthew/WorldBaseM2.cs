using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBaseM2: MonoBehaviour {
	/* List of constants. */
	public const int SPAWN_OFFSET = 25;

	/* This GameObject should be linked to the player character. */
	public GameObject pc;

	/* This structure stores the location of each object and a link to that object. */
	public struct WorldEntry {
		public Vector3 loc;
		public GameObject obj;
	}

	/* List to all the GameObjects in the level. */
	public List<WorldEntry> levelObjects = new List<WorldBaseM2.WorldEntry> ();

	public void WorldStart () {
		// Sorting level by x position
		levelObjects.Sort ((x, y) => x.loc.x.CompareTo (y.loc.x));
		updateWorld ();
	//	pc.transform.position = new Vector3 (pc.transform.position.x + 250, 1, 0); 
	}	

	public void addEntry (float x, float y, float z, GameObject gameObject) {
		WorldEntry entry = new WorldEntry ();
		entry.loc = new Vector3 (x, y, z);
		entry.obj = gameObject;
		levelObjects.Add (entry);
	}
		
	public void updateWorld () {
		Vector3 pcPos = pc.transform.position;
		while (levelObjects.Count > 0) {
			WorldEntry entry = levelObjects [0];
			if (entry.loc.x < pcPos.x + SPAWN_OFFSET) {
				Instantiate (entry.obj, entry.loc, Quaternion.identity);
				levelObjects.RemoveAt (0);
			} else {
				return;
			}
		}
			
	}
}
