using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeLevel : MonoBehaviour {

	public GameObject ground;
	public GameObject column;


	// Use this for initialization
	void Start () {
		// Reference to this scene's world_base
		WorldBase wb = GetComponent<WorldBase> ();

		// Adding one column to level
		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();
		WorldBase.WorldEntry blockentry = new WorldBase.WorldEntry ();
		blockentry.loc = new Vector3 (20, 0, 0);
		blockentry.obj = column;
		thisLevel.Add(blockentry);

		// Adding 80 brown_grounds to level
		for (int i = 0; i < 80; i++) {
			WorldBase.WorldEntry entry = new WorldBase.WorldEntry ();

			float blockWidth = ground.GetComponent<BoxCollider2D> ().size.x; //   bounds.size.x;
			entry.loc = new Vector3 (i*blockWidth, 0, 0);
			entry.obj = ground;
			thisLevel.Add (entry);
		}

		// Sorting level by x position
		thisLevel.Sort((x, y) => x.loc.x.CompareTo(y.loc.x));

		wb.WorldStart (thisLevel);


	}
	
	// Update is called once per frame
	void Update () {
//		WorldUpdate ();
	}
}
