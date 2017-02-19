﻿using System.Collections;
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
	public GameObject up_gravity_pointer;
	public GameObject down_gravity_pointer;

	// Use this for initialization
	void Start () {
		WorldBase wb = GetComponent<WorldBase> ();

		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();

		int level_length = 275;
		// Constructing the level's components

		for (int round = 0; round < 10; round++) {
			float groundWidth = ground.GetComponent<BoxCollider2D> ().size.x; 
			float groundHeight = ground.GetComponent<BoxCollider2D> ().size.y;

			float offset = round * level_length * groundWidth;
		



			// Adding 300 grounds to level
			for (int i = 0; i < level_length; i++) {
				WorldBase.WorldEntry ground_entry = new WorldBase.WorldEntry ();

				ground_entry.loc = new Vector3 (offset + (i * groundWidth), 0, 0);
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
			float numCeil = (level_length - 120) * groundWidth / ceilingWidth;
//		float ceilingHeight = ceiling.GetComponent<BoxCollider2D> ().size.y/4;
			for (int i = 0; i < numCeil; i++) {
				WorldBase.WorldEntry ceiling_entry = new WorldBase.WorldEntry ();

				ceiling_entry.loc = new Vector3 (offset + ceilingStart + i * ceilingWidth, ceilingY, 0);
				ceiling_entry.obj = ceiling;
				thisLevel.Add (ceiling_entry);
			}


			int[] spike_locs = new int[]{ 20, 35, 90, 91, 110, 114, 118, 168, 171, 179, 181, 225, 231, 232, 250, 254, 258 };
			Vector2[] spoints = spike.GetComponent<PolygonCollider2D> ().points;
			float spikeHeight = (spoints [2].y - spoints [0].y) * spike.transform.localScale.y * 2/3;
			foreach (int val in spike_locs) {
				WorldBase.WorldEntry spike_entry = new WorldBase.WorldEntry ();
				spike_entry.loc = new Vector3 (offset + val * groundWidth, groundHeight / 2 + spikeHeight / 2, 0);
				spike_entry.obj = spike;
				thisLevel.Add (spike_entry);
			}



			int[] taller_spike_locs = new int[]{ 50, 97, 103, 123, 205, 240, 264 };
			Vector2[] tspoints = tall_spike.GetComponent<PolygonCollider2D> ().points;
			float tallerSpikeHeight = (tspoints [2].y - tspoints [0].y) * tall_spike.transform.localScale.y * 2/3;

			foreach (int val in taller_spike_locs) {
				WorldBase.WorldEntry taller_spike_entry = new WorldBase.WorldEntry ();
				taller_spike_entry.obj = tall_spike;
				taller_spike_entry.loc = new Vector3 (offset + val * groundWidth, groundHeight / 2 + tallerSpikeHeight / 2, 0);
				thisLevel.Add (taller_spike_entry);
			} 

			int[] ud_spike_locs = new int[]{ 145, 150, 160, 191, 199, 209 };
			foreach (int val in ud_spike_locs) {
				WorldBase.WorldEntry ud_spike_entry = new WorldBase.WorldEntry ();
				ud_spike_entry.obj = ud_spike;
				ud_spike_entry.loc = new Vector3 (offset + val * groundWidth, ceilingY - ceilingWidth / 2 - spikeHeight / 2, 0);
				thisLevel.Add (ud_spike_entry);
			}

			int[] ud_tall_spike_locs = new int[]{ 155, 165, 175, 185 };
			foreach (int val in ud_tall_spike_locs) {
				WorldBase.WorldEntry ud_tall_spike_entry = new WorldBase.WorldEntry ();
				ud_tall_spike_entry.obj = ud_tall_spike;
				ud_tall_spike_entry.loc = new Vector3 (offset + val * groundWidth, ceilingY - ceilingWidth / 2 - tallerSpikeHeight / 2, 0);
				thisLevel.Add (ud_tall_spike_entry);
			}


			Vector2[] ttspoints = too_tall_spike.GetComponent<PolygonCollider2D> ().points;
			float tooTallSpikeHeight = (ttspoints [2].y - ttspoints [0].y) * too_tall_spike.transform.localScale.y * 2/3;
			WorldBase.WorldEntry too_tall_spike_entry = new WorldBase.WorldEntry ();
			too_tall_spike_entry.obj = too_tall_spike;
			too_tall_spike_entry.loc = new Vector3 (offset + 65 * groundWidth, groundHeight / 2 + tooTallSpikeHeight / 2, 0);
			thisLevel.Add (too_tall_spike_entry);

			float batteryHeight = battery.GetComponent<BoxCollider2D> ().size.y * battery.transform.localScale.y;
			int[] battery_locs = new int[]{ 75, 127 };
			foreach (int val in battery_locs) {
				WorldBase.WorldEntry battery_entry = new WorldBase.WorldEntry ();
				battery_entry.obj = battery;
				battery_entry.loc = new Vector3 (offset + val * groundWidth, groundHeight / 2 + batteryHeight / 2, 0);
				thisLevel.Add (battery_entry);
			}

			int[] ud_battery_locs = new int[]{ 168, 203 };
			foreach (int val in ud_battery_locs) {
				WorldBase.WorldEntry battery_entry = new WorldBase.WorldEntry ();
				battery_entry.obj = battery;
				battery_entry.loc = new Vector3 (offset + val * groundWidth, ceilingY - ceilingWidth / 2 - batteryHeight / 2, 0);
				thisLevel.Add (battery_entry);
			}

			int[] gravity_locs = new int[]{ 130, 131, 132, 133 };
			//		float gravityHeight = gravity_pointer.GetComponent<BoxCollider2D> ().size.y * gravity_pointer.transform.localScale.y;
			foreach (int val in gravity_locs) {
				for (int i = 1; i < 4; i++) {
					WorldBase.WorldEntry gravity_entry = new WorldBase.WorldEntry ();
					gravity_entry.obj = up_gravity_pointer;
					gravity_entry.loc = new Vector3 (offset + val * groundWidth, groundHeight * i, 0);
					thisLevel.Add (gravity_entry);
				}
			}

			int[] reverse_gravity_locs = new int[]{ 213, 214, 215, 216 };
			foreach (int val in reverse_gravity_locs) {
				for (int i = 1; i < 4; i++) {
					WorldBase.WorldEntry gravity_entry = new WorldBase.WorldEntry ();
					gravity_entry.obj = down_gravity_pointer;
					gravity_entry.loc = new Vector3 (offset + val * groundWidth, ceilingY - groundHeight * 2 * i / 2, 0);
					thisLevel.Add (gravity_entry);
				}
			}

			float coinHeight = coin.GetComponent<BoxCollider2D> ().size.y * coin.transform.localScale.y;
			Dictionary<float, float> coin_locs = new Dictionary<float, float>
			{
				{ 27, groundHeight / 2 + coinHeight},
				{ 112, groundHeight / 2 + coinHeight },
				{ 116, groundHeight / 2 + coinHeight },
				{ taller_spike_locs [1], groundHeight / 2 + tallerSpikeHeight + coinHeight * 3 / 2},
				{ ud_tall_spike_locs [2], ceilingY - ceilingWidth / 2 - tallerSpikeHeight - coinHeight * 3 / 2},
				{ reverse_gravity_locs [1], groundHeight / 2 + coinHeight}
			};

			foreach (var element in coin_locs) {
				WorldBase.WorldEntry coin_entry = new WorldBase.WorldEntry ();
				coin_entry.obj = coin;
				coin_entry.loc = new Vector3 (offset + element.Key * groundWidth, element.Value, 0);
				thisLevel.Add (coin_entry);
			}

		}
		// Sorting level by x position
		thisLevel.Sort ((x, y) => x.loc.x.CompareTo (y.loc.x));

		wb.WorldStart (thisLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
