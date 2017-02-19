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
	public GameObject up_gravity_pointer;
	public GameObject down_gravity_pointer;

	// Use this for initialization
	void Start () {
		WorldBase wb = GetComponent<WorldBase> ();
		wb.levelObjects = new List<WorldBase.WorldEntry> ();
//		List<WorldBase.WorldEntry> thisLevel = new List<WorldBase.WorldEntry> ();

		int level_length = 275;
		// Constructing the level's components

//		for (int round = 0; round < 10; round++) {
		float groundWidth = ground.GetComponent<BoxCollider2D> ().size.x; 
		float groundHeight = ground.GetComponent<BoxCollider2D> ().size.y;

//			float offset = round * level_length * groundWidth;
		

		// Adding ground
		List<float> ground_x_locs = new List<float> ();
		List<float> ground_y_locs = new List<float> ();
		// Adding 300 grounds to level
		for (int i = 0; i < level_length; i++) {
			ground_x_locs.Add(i * 2);
			ground_y_locs.Add(0);
		}
		wb.AddObjects (ground_x_locs, ground_y_locs, ground);


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

		// Adding ceiling
		float ceilingWidth = ceiling.GetComponent<BoxCollider2D> ().size.x * ceiling.transform.localScale.y; 
		float ceilingHeight = ceilingWidth;
		float ceilingY = ceilingWidth * 8.7f; // ceilingWidth == ceilingHeight here
		float ceilingStart = groundWidth * 120;
		float numCeil = (level_length - 120) * groundWidth / ceilingWidth;

		List<float> ceiling_x_locs = new List<float> ();
		List<float> ceiling_y_locs = new List<float> ();
		for (float i = 0; i < numCeil; i++) {
			ceiling_x_locs.Add (ceilingStart + i * ceilingWidth);
			ceiling_y_locs.Add (ceilingY);
		}
		wb.AddObjects (ceiling_x_locs, ceiling_y_locs, ceiling);

		// Adding spikes
		Vector2[] spoints = spike.GetComponent<PolygonCollider2D> ().points;
		float spikeHeight = (spoints [2].y - spoints [0].y) * spike.transform.localScale.y * 2/3;
		List<float> spike_x_locs = new List<float> {20, 35, 90, 91, 110, 114, 118, 168, 171, 179, 181, 225, 231, 232, 250, 254, 258 };
		List<float> spike_y_locs = new List<float> ();
		for (int i = 0; i < spike_x_locs.Count; i++) {
			spike_x_locs[i] *= 2;
			spike_y_locs.Add (groundHeight / 2 + spikeHeight / 2);
		}
		wb.AddObjects (spike_x_locs, spike_y_locs, spike);

		// Adding tall spikes
		List<float> tall_spike_x_locs = new List<float> { 50, 97, 103, 123, 205, 240, 264 };
		Vector2[] tspoints = tall_spike.GetComponent<PolygonCollider2D> ().points;
		float tallSpikeHeight = (tspoints [2].y - tspoints [0].y) * tall_spike.transform.localScale.y * 2/3;
		List<float> tall_spike_y_locs = new List<float> ();
		for (int i = 0; i < tall_spike_x_locs.Count; i++) {
			tall_spike_x_locs[i] *= 2;
			tall_spike_y_locs.Add (groundHeight / 2 + tallSpikeHeight / 2);
		}
		wb.AddObjects (tall_spike_x_locs, tall_spike_y_locs, tall_spike);

		// Adding upside down spikes
		List<float> ud_spike_x_locs = new List<float> { 145, 150, 160, 191, 199, 209 };
		List<float> ud_spike_y_locs = new List<float> ();
		for (int i = 0; i < ud_spike_x_locs.Count; i++) {
			ud_spike_x_locs[i] *= 2;
			ud_spike_y_locs.Add (ceilingY - ceilingHeight / 2 - spikeHeight / 2);
		}
		wb.AddObjects (ud_spike_x_locs, ud_spike_y_locs, ud_spike);

		// Adding upside down tall spikes
		List<float> ud_tall_spike_x_locs = new List<float> { 155, 165, 175, 185 };
		List<float> ud_tall_spike_y_locs = new List<float> ();
		for (int i = 0; i < ud_tall_spike_x_locs.Count; i++) {
			ud_tall_spike_x_locs[i] *= 2;
			ud_tall_spike_y_locs.Add (ceilingY - ceilingHeight / 2 - tallSpikeHeight / 2);
		}
		wb.AddObjects (ud_tall_spike_x_locs, ud_tall_spike_y_locs, ud_tall_spike);

		// Adding unpassable spike
		Vector2[] ttspoints = too_tall_spike.GetComponent<PolygonCollider2D> ().points;
		float tooTallSpikeHeight = (ttspoints [2].y - ttspoints [0].y) * too_tall_spike.transform.localScale.y * 2/3;
		wb.AddObject (65 * 2, groundHeight / 2 + tooTallSpikeHeight / 2, too_tall_spike);

		// Adding batteries
		float batteryHeight = battery.GetComponent<BoxCollider2D> ().size.y * battery.transform.localScale.y;
		List<float> battery_x_locs = new List<float> { 150, 254, 336, 406 };
		List<float> battery_y_locs = new List<float> { groundHeight / 2 + batteryHeight / 2, groundHeight / 2 + batteryHeight / 2,
			ceilingY - ceilingWidth / 2 - batteryHeight / 2, ceilingY - ceilingWidth / 2 - batteryHeight / 2
		};
		wb.AddObjects (battery_x_locs, battery_y_locs, battery);

		// Adding gravity reversers
		List<float> gravity_up_x_locs = new List<float> { 260, 262, 264, 266 };
		List<float> gravity_up_y_locs = new List<float> ();
		for (int i = 1; i < 4; i++) {
			foreach (float val in gravity_up_x_locs) {
				gravity_up_y_locs.Add (groundHeight * i);
			}
			wb.AddObjects (gravity_up_x_locs, gravity_up_y_locs, up_gravity_pointer);
			gravity_up_y_locs.Clear ();
		}

		// Adding gravity normalizers
		List<float> gravity_down_x_locs = new List<float> { 426, 428, 430, 432 };
		List<float> gravity_down_y_locs = new List<float> ();
		for (int i = 1; i < 4; i++) {
			foreach (float val in gravity_down_x_locs) {
				gravity_down_y_locs.Add (ceilingY - groundHeight * 2 * i / 2);
			}
			wb.AddObjects (gravity_down_x_locs, gravity_down_y_locs, down_gravity_pointer);
			gravity_down_y_locs.Clear ();
		}

		// Adding coins
		float coinHeight = coin.GetComponent<BoxCollider2D> ().size.y * coin.transform.localScale.y;
		float ground_coin = groundHeight / 2 + coinHeight;
		List<float> coin_x_locs = new List<float> { 54, 224, 232, tall_spike_x_locs [1], ud_tall_spike_x_locs [2], gravity_down_x_locs [1]};
		List<float> coin_y_locs = new List<float> { ground_coin, ground_coin, ground_coin, groundHeight / 2 + tallSpikeHeight + coinHeight * 3 / 2,
			ceilingY - ceilingWidth / 2 - tallSpikeHeight - coinHeight * 3 / 2, ground_coin};
		wb.AddObjects (coin_x_locs, coin_y_locs, coin);

		wb.WorldStart ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
