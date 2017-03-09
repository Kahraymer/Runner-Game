using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelM2script : WorldBaseM2 {
	/* List of constants. */
	private const float LVL_LENGTH = 1000; // Length of the entire level.
	private const float START_X = -2; // Default x position for the first row of objects.
	private const float DEFAULT_Y = 0; // Default y position for the bottom row of objects.
	private const float DEFAULT_Z = 0; // Default z position for all world objects.

	/*** BACKGROUND ***/
	public GameObject bckgrndFallingObj;
	public GameObject background;
	private const float BACKGROUND_Z = 5; // Default z position for background objects.

	/*** GROUND ***/
	public GameObject groundObj;
	private const float GRND_Y = -0.3f;

	/*** CEILING ***/
	public GameObject ceiling;
	private const float CEIL_Y = 8.75f;

	/*** GROUND OBSTACLES ***/
	public GameObject spike;
	private const float GRND_OBS_Z = -1f;
	private const float SML_GRND_OBS_Y = .75f;
	private static readonly float[] smallGrndObstaclesXPos = { 15, 25, 33, 38, 43, 48, 49, 54, 55, 56, 61, 62, 63, 64 };

	public GameObject tall_spike;
	private const float MED_GRND_OBS_Y = .75f;
	private static readonly float[] medGrndObstaclesXPos = { 69, 74, 74.5f, 80, 80.5f, 90, 91, 92 };

	/*** CEILING OBSTACLES ***/
	public GameObject ud_spike;
	public GameObject ud_tall_spike;
	private const float SML_CEIL_OBS_Y = 10f;
	private const float MED_CEIL_OBS_Y = 10f;

	/*** BATTERIES ***/
	public GameObject battery;

	/*** COINS ***/
	public GameObject coin;
	public GameObject coinArcObj;
	public GameObject superCoinObj;

	private const float GRND_COIN_Y = 1;
	private static readonly float[] coinsXPos = { 5, 7, 9, 11, 13 };
	private static readonly float[] coinArcXPos = {  };
	private static readonly float[] superCoinXPos = {  };

	private const float CEIL_COIN_Y = 10;
	private static readonly float[] ceilCoinsXPos = {  };
	private static readonly float[] ceilCoinArcXPos = {  };
	private static readonly float[] ceilSuperCoinXPos = {  };

	/*** DROPPERS ***/
	public GameObject sawDropperObj;
	public GameObject batteryDropperObj;
	private const float DROPPER_Y = 8.5f; // Default y position for dropper objects.
	private const float DROPPER_Z = -1f;
	private static readonly float[] batteryDropperXPos = { };
	private static readonly float[] sawDropperXPos = { };

	/*** GRAVITY ***/
	public GameObject up_gravity_pointer;
	public GameObject down_gravity_pointer;
	private const float GRAV_Y = 1f;
	private static readonly float[] reverseGravXPos = { };
	private static readonly float[] normalGravXPos = { };


	/*** LEVEL END ***/
	public GameObject levelEndObj;
	private const float LVL_END = 985; // Where the player sees the end of level.
	private const float LVL_END_Y = 3.75f; // Default y position for level end objects.

	/*** FRAMERATE ***/
	private const int FRAMERATE = 60; // Default framerate.

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = FRAMERATE;

		addBackground ();
		addGround ();
		addCeiling ();

		addSmallGroundObstacles ();
		addMedGroundObstacles ();

		addCoin ();
		//addGrndCoinArcs ();

		//addSawDroppers ();
		//addBatterDroppers ();


		//addReverseGravity ();
		//addNormalGravity ();

		//addLevelEnd ();
		WorldStart ();
	}

	// Update is called once per frame
	void Update () {
		updateWorld ();
	}

	/* This function takes an array of x values, a y value, and a z value and puts an
	 * object of the same type at each point. */
	private void addArray (float[] x_pos, float y, float z, GameObject obj) {
		for (int i = 0; i < x_pos.Length; i++) {
			addEntry (x_pos[i], y, z, obj);
		}
	}

	private void addBackground () {
		int num_objects = (int) (LVL_LENGTH);
		for (int i = 0; i < num_objects; i += 20) {
			for (int j = 0; j < 5; j++) {
				float x = Random.Range (i, i + 15); 
				float botBound = GRND_Y + 1f;
				float topBound = CEIL_Y - 1f;
				float y = Random.Range (botBound, topBound);
				addEntry (x + j, y, BACKGROUND_Z, bckgrndFallingObj);
			}
		}
	}

	private void addGround () {
		float width = groundObj.GetComponent<BoxCollider2D> ().size.x;
		int num_objects = (int) (LVL_LENGTH / width);
		for (int i = (int) START_X; i < num_objects; i++) {
			addEntry (i, GRND_Y, DEFAULT_Z, groundObj);
		}
	}

	private void addCeiling () {
		float width = ceiling.GetComponent<BoxCollider2D> ().size.y;
		int num_objects = (int)(LVL_LENGTH / width);
		for (int i = (int)START_X; i < num_objects; i++) {
			addEntry (i, CEIL_Y, DEFAULT_Z, ceiling);
		}
		
	}

	private void addSmallGroundObstacles () {
		addArray (smallGrndObstaclesXPos, SML_GRND_OBS_Y, GRND_OBS_Z, spike);
	}

	private void addMedGroundObstacles () {
		addArray (medGrndObstaclesXPos, MED_GRND_OBS_Y, GRND_OBS_Z, tall_spike);
	}

	private void addCoin () {
	//	for (int i = 5; i < LVL_LENGTH - 10; i += 2) {
	//		addEntry (i, GRND_COIN_Y, DEFAULT_Z, coin);
	//	}
		addArray (coinsXPos, GRND_COIN_Y, DEFAULT_Z, coin);
	}

	private void addGrndCoinArcs () {
		addArray (coinArcXPos, GRND_COIN_Y, DEFAULT_Z, coinArcObj);
	}
		
	private void addSawDroppers () {
		addArray (sawDropperXPos, DROPPER_Y, DROPPER_Z, sawDropperObj);
	}

	private void addBatterDroppers () {
		addArray (batteryDropperXPos, DROPPER_Y, DROPPER_Z, batteryDropperObj);
	}

	private void addReverseGravity () {
		addArray (reverseGravXPos, GRAV_Y, DEFAULT_Z, up_gravity_pointer);
	}

	private void addNormalGravity () {
		addArray (normalGravXPos, GRAV_Y, DEFAULT_Z, down_gravity_pointer);
	}

	private void addLevelEnd () {
		addEntry (LVL_END, LVL_END_Y, DEFAULT_Z, levelEndObj);
	}
}
	