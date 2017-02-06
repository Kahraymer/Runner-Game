using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonicaPracticeLevel : MonoBehaviour {

	public GameObject mground;
	public GameObject mcolumn;


	// Use this for initialization
	void Start () {
		// Reference to this scene's world_base
		MonicaWorldBase wb = GetComponent<MonicaWorldBase> ();

		// Adding one mcolumn to level
		List<MonicaWorldBase.MonicaWorldEntry> thisLevel = new List<MonicaWorldBase.MonicaWorldEntry> ();
		MonicaWorldBase.MonicaWorldEntry blockentry = new MonicaWorldBase.MonicaWorldEntry ();
		blockentry.loc = new Vector3 (20, 0, 0);
		blockentry.obj = mcolumn;
		thisLevel.Add(blockentry);

		// Adding 80 brown_mgrounds to level
		for (int i = 0; i < 80; i++) {
			MonicaWorldBase.MonicaWorldEntry entry = new MonicaWorldBase.MonicaWorldEntry ();

			float blockWidth = mground.GetComponent<BoxCollider2D> ().size.x; //   bounds.size.x;
			entry.loc = new Vector3 (i*blockWidth, 0, 0);
			entry.obj = mground;
			thisLevel.Add (entry);
		}

		// Sorting level by x position
		thisLevel.Sort((x, y) => x.loc.x.CompareTo(y.loc.x));

		wb.MonicaWorldStart (thisLevel);


	}

	// Update is called once per frame
	void Update () {
//		WorldUpdate ();
	}
}
