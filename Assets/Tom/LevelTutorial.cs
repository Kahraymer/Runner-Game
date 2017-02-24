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
	public GameObject end_level;

	// Number of ground blocks 
	private int level_length = 360;

	private float groundWidth;
	private float groundHeight;
	private float ceilingWidth;
	private float ceilingHeight;
	private float ceilingY;
	private float ceilingStart;
	private float numCeil;
	private float spikeHeight;
	private float tallSpikeHeight;
	private float tooTallSpikeHeight;
	private float batteryHeight; 
	private float ground_battery;
	private float ceiling_battery;
	private float coinHeight;
	private float ground_coin;
	private float ceiling_coin;


	// Use this for initialization
	void Start () {
		WorldBase wb = GetComponent<WorldBase> ();
		wb.levelObjects = new List<WorldBase.WorldEntry> ();

		InitConstants ();

		AddGroundBlocks (wb);
		AddCeilingBlocks (wb);
		AddSpikes (wb);
		AddBatteries (wb);
		AddGravityChangers (wb);
		AddCoins (wb);


//		wb.backgroundObjects = new List<WorldBase.WorldEntry> ();

//		// For background of level. I couldn't figure out the layering...
//		float bgWidth = background.GetComponent<BoxCollider2D> ().size.x; 
//		float bgHeight = background.GetComponent<BoxCollider2D> ().size.y;
//		float numbg = level_length * groundWidth / bgWidth;
//		wb.AddBackground (10, 4, background);
//		wb.AddBackground (20, 4, background);

		GameObject end_level = GameObject.FindGameObjectWithTag ("EndLevel");
		wb.AddObject (680, 0, end_level);

		wb.WorldStart ();
	}

	private void AddGroundBlocks (WorldBase wb) {
		// Adding ground
		List<float> ground_x_locs = new List<float> ();
		List<float> ground_y_locs = new List<float> ();
		for (int i = 0; i < level_length; i++) {
			ground_x_locs.Add(i * groundWidth);
			ground_y_locs.Add(0);
		}
		wb.AddObjects (ground_x_locs, ground_y_locs, ground);
	}

	private void AddCeilingBlocks (WorldBase wb) {
		// Adding ceiling
		List<float> ceiling_x_locs = new List<float> ();
		List<float> ceiling_y_locs = new List<float> ();
		for (float i = 0; i < numCeil; i++) {
			ceiling_x_locs.Add (ceilingStart + i * ceilingWidth);
			ceiling_y_locs.Add (ceilingY);
		}
		wb.AddObjects (ceiling_x_locs, ceiling_y_locs, ceiling);
	}
		
	private void AddSpikes (WorldBase wb) {
		// Adding spikes
		List<float> spike_x_locs = new List<float> {40, 70, 180, 182, 220, 228, 236, 336, 342, 358, 362, 450, 462, 464, 500, 503, 516, 522, 528};
		List<float> spike_y_locs = new List<float> ();
		for (int i = 0; i < spike_x_locs.Count; i++) {
			spike_y_locs.Add (groundHeight / 2 + spikeHeight / 2);
		}
		wb.AddObjects (spike_x_locs, spike_y_locs, spike);

		// Adding tall spikes
		List<float> tall_spike_x_locs = new List<float> { 100, 194, 206, 246, 410, 480};
		List<float> tall_spike_y_locs = new List<float> ();
		for (int i = 0; i < tall_spike_x_locs.Count; i++) {
			tall_spike_y_locs.Add (groundHeight / 2 + tallSpikeHeight / 2);
		}
		wb.AddObjects (tall_spike_x_locs, tall_spike_y_locs, tall_spike);

		// Adding upside down spikes
		List<float> ud_spike_x_locs = new List<float> { 290, 300, 320, 382, 398, 418, 516, 522, 528, 
			585, 586, 596, 598, 608, 611, 621, 625, 635, 640 }; 
		List<float> ud_spike_y_locs = new List<float> ();
		for (int i = 0; i < ud_spike_x_locs.Count; i++) {
			ud_spike_y_locs.Add (ceilingY - ceilingHeight / 2 - spikeHeight / 2);
		}
		wb.AddObjects (ud_spike_x_locs, ud_spike_y_locs, ud_spike);

		// Adding upside down tall spikes
		List<float> ud_tall_spike_x_locs = new List<float> { 310, 330, 350, 370 };
		List<float> ud_tall_spike_y_locs = new List<float> ();
		for (int i = 0; i < ud_tall_spike_x_locs.Count; i++) {
			ud_tall_spike_y_locs.Add (ceilingY - ceilingHeight / 2 - tallSpikeHeight / 2);
		}
		wb.AddObjects (ud_tall_spike_x_locs, ud_tall_spike_y_locs, ud_tall_spike);

		// Adding unpassable spike
		wb.AddObject (65 * 2, groundHeight / 2 + tooTallSpikeHeight / 2, too_tall_spike);
	}

	private void AddBatteries (WorldBase wb) {
		// Adding batteries
		List<float> battery_x_locs = new List<float> { 150, 254, 336, 406, 545 };
		List<float> battery_y_locs = new List<float> { ground_battery, ground_battery, ceiling_battery, ceiling_battery, ground_battery};
		wb.AddObjects (battery_x_locs, battery_y_locs, battery);
	}

	private void AddGravityChangers (WorldBase wb) {
		// Adding gravity reversers
		List<float> gravity_up_x_locs = new List<float> { 260, 262, 264, 266, 560, 562 };
		List<float> gravity_up_y_locs = new List<float> ();
		for (int i = 1; i < 5; i++) {
			foreach (float val in gravity_up_x_locs) {
				gravity_up_y_locs.Add (groundHeight * (i-0.2f));
			}
			wb.AddObjects (gravity_up_x_locs, gravity_up_y_locs, up_gravity_pointer);
			gravity_up_y_locs.Clear ();
		}

		// Adding gravity normalizers
		List<float> gravity_down_x_locs = new List<float> { 426, 428, 430, 432, 650, 652 };
		List<float> gravity_down_y_locs = new List<float> ();
		for (int i = 1; i < 5; i++) {
			foreach (float val in gravity_down_x_locs) {
				gravity_down_y_locs.Add (groundHeight * (i-0.2f));
			}
			wb.AddObjects (gravity_down_x_locs, gravity_down_y_locs, down_gravity_pointer);
			gravity_down_y_locs.Clear ();
		}
	}

	private void AddCoins (WorldBase wb) {
		// Adding coins
		Dictionary<float, float> coin_locs = new Dictionary<float, float> {
			{ 54, ground_coin },
			{ 88, ground_coin },
			{ 90, ground_coin },
			{ 92, ground_coin },
			{ 181, ground_coin + spikeHeight + 3 * coinHeight / 2 },
			{ 224, ground_coin },
			{ 232, ground_coin },
			{ 194, groundHeight / 2 + tallSpikeHeight + coinHeight * 3 / 2 },
			{ 350, ceilingY - ceilingWidth / 2 - tallSpikeHeight - coinHeight * 3 / 2 },
			{ 428, ground_coin },
			{ 544, ground_coin + tallSpikeHeight + coinHeight },
			{ 546, ground_coin + tallSpikeHeight + coinHeight },
			{ 357, ceiling_coin}, {360, ceiling_coin - 2*coinHeight}, {363, ceiling_coin},
			{ 501.5f, ground_coin + tallSpikeHeight},
			{516, (ground_coin + ceiling_coin) / 2}, {522, (ground_coin + ceiling_coin) / 2}, {528, (ground_coin + ceiling_coin) / 2},
			{ 585.5f, ceiling_coin - tallSpikeHeight - coinHeight},
			{ 597, ceiling_coin - tallSpikeHeight - coinHeight},
			{ 609.5f, ceiling_coin - tallSpikeHeight - coinHeight},
			{ 623, ceiling_coin - tallSpikeHeight - coinHeight},
			{ 637.5f, ceiling_coin - tallSpikeHeight - coinHeight},
		};
		wb.AddObjects (coin_locs, coin);
	}

<<<<<<< HEAD
	private void InitConstants() {
		groundWidth = ground.GetComponent<BoxCollider2D> ().size.x; 
		groundHeight = ground.GetComponent<BoxCollider2D> ().size.y;
		ceilingWidth = ceiling.GetComponent<BoxCollider2D> ().size.x * ceiling.transform.localScale.y; 
		ceilingHeight = ceilingWidth;
		ceilingY = ceilingWidth * 8.7f; // ceilingWidth == ceilingHeight here
		ceilingStart = groundWidth * 120;
		numCeil = (level_length - 120) * groundWidth / ceilingWidth;
		Vector2[] spoints = spike.GetComponent<PolygonCollider2D> ().points;
		spikeHeight = (spoints [2].y - spoints [0].y) * spike.transform.localScale.y * 2/3;
		Vector2[] tspoints = tall_spike.GetComponent<PolygonCollider2D> ().points;
		tallSpikeHeight = (tspoints [2].y - tspoints [0].y) * tall_spike.transform.localScale.y * 2/3;
		Vector2[] ttspoints = too_tall_spike.GetComponent<PolygonCollider2D> ().points;
		tooTallSpikeHeight = (ttspoints [2].y - ttspoints [0].y) * too_tall_spike.transform.localScale.y * 2/3;
		batteryHeight = battery.GetComponent<BoxCollider2D> ().size.y * battery.transform.localScale.y;
		ground_battery = groundHeight / 2 + batteryHeight / 2;
		ceiling_battery = ceilingY - ceilingWidth / 2 - batteryHeight / 2;
		coinHeight = coin.GetComponent<BoxCollider2D> ().size.y * coin.transform.localScale.y;
		ground_coin = groundHeight / 2 + coinHeight;
		ceiling_coin = ceilingY - ceilingHeight / 2 - coinHeight;
=======
		wb.AddObject (20, 4.8f, end_level);

		wb.WorldStart ();
>>>>>>> origin/master
	}

	// Update is called once per frame
	void Update () {
		
	}
}
