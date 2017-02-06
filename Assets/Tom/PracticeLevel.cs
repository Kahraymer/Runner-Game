using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeLevel : MonoBehaviour {

	public GameObject ground;
//	public GameObject level_pc;
//	public GameObject mypc;
//	public GameObject coin;


	// Use this for initialization
	void Start () {
		Debug.Log ("PRACTICELEVEL START");

		WorldBase wb = GetComponent<WorldBase> ();

		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();

		for (int i = 0; i < 80; i++) {
			WorldBase.WorldEntry entry = new WorldBase.WorldEntry ();

			float blockWidth = ground.GetComponent<BoxCollider2D> ().size.x; //   bounds.size.x;
			Debug.Log ("BLOCKWIDTH IS " + blockWidth);
			Debug.Log ("i * blockWidth is " + i*blockWidth);
			entry.loc = new Vector3 (4 + i*blockWidth, 0, 0);
			entry.obj = ground;
			thisLevel.Add (entry);
		}

		wb.WorldStart (thisLevel);


	}
	
	// Update is called once per frame
	void Update () {
//		WorldUpdate ();
	}
}
