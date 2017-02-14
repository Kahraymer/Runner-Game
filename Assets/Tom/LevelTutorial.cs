using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTutorial : MonoBehaviour {

	// Script for the construction of the tutorial level
	// Will possibly include basic instructions for player, if necessary

	public GameObject background;
	public GameObject ground;
	public GameObject ceiling;
	public GameObject spike;
	public GameObject tall_spike;
	public GameObject too_tall_spike;
	public GameObject battery;
	public GameObject coin;
	public GameObject ud_spike;
	public GameObject ud_tall_spike;

	// Use this for initialization
	void Start () {
		WorldBase wb = GetComponent<WorldBase> ();

		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();

		int level_length = 300;
		// Constructing the level's components



		float groundWidth = ground.GetComponent<BoxCollider2D> ().size.x; 
		float groundHeight = ground.GetComponent<BoxCollider2D> ().size.y;
		// Adding 300 grounds to level
		for (int i = 0; i < level_length; i++) {
			WorldBase.WorldEntry ground_entry = new WorldBase.WorldEntry ();

			ground_entry.loc = new Vector3 (i*groundWidth, 0, 0);
			ground_entry.obj = ground;
			thisLevel.Add (ground_entry);
		}


//		// For background of level. I couldn't figure out the layering...
//		float bgWidth = background.GetComponent<BoxCollider2D> ().size.x; 
//		float bgHeight = background.GetComponent<BoxCollider2D> ().size.y;
//		float numbg = level_length * groundWidth / bgWidth;
//		for (int i = 0; i < numbg; i++) {
//			WorldBase.WorldEntry bg_entry = new WorldBase.WorldEntry ();
//
//			bg_entry.loc = new Vector3 (i*bgWidth, groundHeight/2 + bgHeight/2, 0);
//			bg_entry.obj = background;
//			thisLevel.Add (bg_entry);
//		}

		float ceilingWidth = ceiling.GetComponent<BoxCollider2D> ().size.x * ceiling.transform.localScale.y; 
		float ceilingY = ceilingWidth * 8.7f; // ceilingWidth == ceilingHeight here
		float ceilingStart = groundWidth * 120;
//		float ceilingHeight = ceiling.GetComponent<BoxCollider2D> ().size.y/4;
		for (int i = 0; i < 300; i++) {
			WorldBase.WorldEntry ceiling_entry = new WorldBase.WorldEntry ();

			ceiling_entry.loc = new Vector3 (ceilingStart + i*ceilingWidth, ceilingY, 0);
			ceiling_entry.obj = ceiling;
			thisLevel.Add (ceiling_entry);
		}


		float spikeHeight = spike.GetComponent<BoxCollider2D> ().size.y;
		int[] spike_locs = new int[]{ 20, 35, 85, 86, 105, 109, 113, 163, 166, 174, 176 };
		foreach (int val in spike_locs) {
			WorldBase.WorldEntry spike_entry = new WorldBase.WorldEntry ();
			spike_entry.loc = new Vector3 (val*groundWidth, groundHeight/2 + spikeHeight/2, 0);
			spike_entry.obj = spike;
			thisLevel.Add (spike_entry);
		}


		int[] taller_spike_locs = new int[]{ 50, 92, 98, 118, 194 };
		float tallerSpikeHeight = tall_spike.GetComponent<BoxCollider2D> ().size.y * tall_spike.transform.localScale.y;
		foreach (int val in taller_spike_locs) {
			WorldBase.WorldEntry taller_spike_entry = new WorldBase.WorldEntry ();
			taller_spike_entry.obj = tall_spike;
			taller_spike_entry.loc = new Vector3 (val*groundWidth, groundHeight/2 + tallerSpikeHeight/2, 0);
			thisLevel.Add (taller_spike_entry);
		}
			

		int[] ud_spike_locs = new int[]{ 130, 135, 140, 155, 185, 190 };
		foreach (int val in ud_spike_locs) {
			WorldBase.WorldEntry ud_spike_entry = new WorldBase.WorldEntry ();
			ud_spike_entry.obj = ud_spike;
			ud_spike_entry.loc = new Vector3 (val*groundWidth, ceilingY - ceilingWidth/2 - spikeHeight/2, 0);
			thisLevel.Add (ud_spike_entry);
		}

		int[] ud_tall_spike_locs = new int[]{ 150, 160, 170, 180};
		foreach (int val in ud_tall_spike_locs) {
			WorldBase.WorldEntry ud_tall_spike_entry = new WorldBase.WorldEntry ();
			ud_tall_spike_entry.obj = ud_tall_spike;
			ud_tall_spike_entry.loc = new Vector3 (val*groundWidth, ceilingY - ceilingWidth/2 - tallerSpikeHeight/2, 0);
			thisLevel.Add (ud_tall_spike_entry);
		}


		float tooTallSpikeHeight = too_tall_spike.GetComponent<BoxCollider2D> ().size.y * too_tall_spike.transform.localScale.y;
		WorldBase.WorldEntry too_tall_spike_entry = new WorldBase.WorldEntry ();
		too_tall_spike_entry.obj = too_tall_spike;
		too_tall_spike_entry.loc = new Vector3 (65*groundWidth, groundHeight/2 + tooTallSpikeHeight/2, 0);
		thisLevel.Add (too_tall_spike_entry);

		float batteryHeight = battery.GetComponent<BoxCollider2D> ().size.y * battery.transform.localScale.y;
		int[] battery_locs = new int[]{ 75, 122 };
		foreach (int val in battery_locs) {
			WorldBase.WorldEntry battery_entry = new WorldBase.WorldEntry ();
			battery_entry.obj = battery;
			battery_entry.loc = new Vector3 (val*groundWidth, groundHeight/2 + batteryHeight/2, 0);
			thisLevel.Add (battery_entry);
		}

		int[] ud_battery_locs = new int[]{ 163, 200 };
		foreach (int val in ud_battery_locs) {
			WorldBase.WorldEntry battery_entry = new WorldBase.WorldEntry ();
			battery_entry.obj = battery;
			battery_entry.loc = new Vector3 (val*groundWidth, ceilingY - ceilingWidth/2 - batteryHeight/2, 0);
			thisLevel.Add (battery_entry);
		}


		// Sorting level by x position
		thisLevel.Sort((x, y) => x.loc.x.CompareTo(y.loc.x));

		wb.WorldStart (thisLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
