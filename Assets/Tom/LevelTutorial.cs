using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTutorial : MonoBehaviour {

	// Script for the construction of the tutorial level
	// Will possibly include basic instructions for player, if necessary

	public GameObject ground;
	public GameObject spike;
	public GameObject tall_spike;
	public GameObject too_tall_spike;
	public GameObject battery;
	public GameObject coin;

	// Use this for initialization
	void Start () {
		WorldBase wb = GetComponent<WorldBase> ();

		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();

		// Constructing the level's components
		float groundWidth = ground.GetComponent<BoxCollider2D> ().size.x; 
		float groundHeight = ground.GetComponent<BoxCollider2D> ().size.y;
		// Adding 300 grounds to level
		for (int i = 0; i < 300; i++) {
			WorldBase.WorldEntry ground_entry = new WorldBase.WorldEntry ();

			ground_entry.loc = new Vector3 (i*groundWidth, 0, 0);
			ground_entry.obj = ground;
			thisLevel.Add (ground_entry);
		}

		float spikeHeight = spike.GetComponent<BoxCollider2D> ().size.y;
		int[] spike_locs = new int[]{ 20, 35, 85, 86, 105, 109, 113 };

		foreach (int val in spike_locs) {
			WorldBase.WorldEntry spike_entry = new WorldBase.WorldEntry ();
			spike_entry.loc = new Vector3 (val*groundWidth, groundHeight/2 + spikeHeight/2, 0);
			spike_entry.obj = spike;
			thisLevel.Add (spike_entry);
		}


		int[] taller_spike_locs = new int[]{ 50, 92, 98, 118 };
		float tallerSpikeHeight = tall_spike.GetComponent<BoxCollider2D> ().size.y;
		foreach (int val in taller_spike_locs) {
			WorldBase.WorldEntry taller_spike_entry = new WorldBase.WorldEntry ();
			taller_spike_entry.obj = tall_spike;
			taller_spike_entry.loc = new Vector3 (val*groundWidth, groundHeight/2 + tallerSpikeHeight/2, 0);
			thisLevel.Add (taller_spike_entry);
		}
			

		float tooTallSpikeHeight = too_tall_spike.GetComponent<BoxCollider2D> ().size.y;
		WorldBase.WorldEntry too_tall_spike_entry = new WorldBase.WorldEntry ();
		too_tall_spike_entry.obj = too_tall_spike;
		too_tall_spike_entry.loc = new Vector3 (65*groundWidth, groundHeight/2 + tooTallSpikeHeight/2, 0);
		thisLevel.Add (too_tall_spike_entry);

		float batteryHeight = battery.GetComponent<BoxCollider2D> ().size.y;
		int[] batterye_locs = new int[]{ 75, 122 };
		WorldBase.WorldEntry battery_entry = new WorldBase.WorldEntry ();
		battery_entry.obj = battery;
		battery_entry.loc = new Vector3 (75*groundWidth, groundHeight/2 + batteryHeight/2, 0);
		thisLevel.Add (battery_entry);

		// Sorting level by x position
		thisLevel.Sort((x, y) => x.loc.x.CompareTo(y.loc.x));

		wb.WorldStart (thisLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
