using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionscript : WorldBaseM2 {
	/* List of constants. */
	private const float LVL_LENGTH = 1200; // Length of the entire level.
	private const float START_X = -2; // Default x position for the first row of objects.
	private const float DEFAULT_Y = 0; // Default y position for the bottom row of objects.
	private const float DEFAULT_Z = 0; // Default z position for all world objects.

	/* LIST OF OBJECTS
	 * 
	 * BACKGROUND
	 * 
	 * GROUND
	 *  * MAIN
	 *  * TRANSITION
	 * 
	 * CEILING
	 *	* MAIN
	 *	* TRANSITION
	 *
	 * GROUND OBSTACLES
	 * 	* SMALL 
	 * 	* MEDIUM
	 * 	* TALL
	 * 
	 * CEILING OBSTACLES
	 *  * SMALL
	 *	* MEDIUM
	 * 
	 * BATTERIES
	 *	* GROUNDED
	 * 
	 * COINS
	 *	* GROUND
	 *	* lOW FLOAT
	 *	* MEDIUM FLOAT
	 *	* HIGH FLOAT
	 *	* CEILING
	 *
	 * DROPPERS
	 * 	* SAW BLADE
	 * 	* BATTERY
	 * 
	 * GRAVITY
	 * 	* REVERSE
	 *  * NORMAL
	 * 
	 * LEVEL END
	 * 
	 * /

	/***** BACKGROUND *****/
	public GameObject bckgrndFallingObj;
	public GameObject background;
	private const float BACKGROUND_Z = 5; // Default z position for background objects.

	/**** GROUND ****/
	public GameObject groundObj;
	public GameObject caveGrndObj;
	private const float GRND_Y = -0.3f;
	private const float CAVE_MIX_BEGIN = 350;
	private const float CAVE_TOTAL_BEGIN = 400;

	/*** CEILING ***/
	public GameObject ceiling;
	public GameObject caveCeilObj;
	private const float CEIL_Y = 8.75f;

	/*** GROUND OBSTACLES ***/
	public GameObject spike;
	private const float GRND_OBS_Z = 1;
	private const float SML_GRND_OBS_Y = .75f;
	private static readonly float[] smallGrndObstaclesXPos = { 15, 25, 34, 42, 47, 53, 59, 65, 91, 
	108, 151, 181, 183, 195, 205, 215, 224, 232, 239, 245, 250, 326  };

	public GameObject tall_spike;
	private const float MED_GRND_OBS_Y = .75f;
	private static readonly float[] medGrndObstaclesXPos = { 81, 100, 115 };

	public GameObject hugeGrndObj;
	private const float HUGE_GRND_OBS_Y = .75f;
	private static readonly float[] hugeGrndObstaclesXPos = { 160.5f, 171 };

	/*** CEILING OBSTACLES ***/
	public GameObject ud_spike;
	public GameObject ud_tall_spike;
	private const float SML_CEIL_OBS_Y = 7.75f;
	private const float CEIL_OBS_Z = 1;
	private static readonly float[] smallCeilObstaclesXPos = { 151, 181 , 195, 205, 215, 224, 232, 239, 
		245, 250, 254.5f};

	private const float MED_CEIL_OBS_Y = 7;
	private static readonly float[] medCeilObstaclesXPos = { 262.5f };

	/*** BATTERIES ***/
	public GameObject battery;
	private const float GRND_BAT_Y = 1;
	private static readonly float[] grndBatXPos = { 139, 257};

	/*** COINS ***/
	public GameObject coin;
	public GameObject superCoinObj;

	private const float GRND_COIN_Y = 1;
	private static readonly float[] grndCoinsXPos = { 5, 7, 9, 11, 13, 17, 19, 21, 23, 26.5f, 28.5f, 30.5f, 
	32.5f, 37.5f, 39.5f, 45.5f, 51, 55, 57, 61, 63, 67, 70, 73, 76, 79, 83, 85, 87, 89, 93, 95, 97,
	103, 105, 109.5f, 111.5f, 113.5f, 117, 119, 121, 123, 127, 129, 131, 135, 137, 141, 143, 145,
	147, 149, 153, 155, 157, 175, 177, 179, 185, 187, 189, 191, 193, 197, 199, 201, 203, 207, 209, 211,
	213, 217, 219, 221, 226, 228, 230, 234, 236, 241, 243, 273.3f, 276.6f, 283.3f, 286.6f, 293.3f,
	296.6f, 303.3f, 306.6f, 313.3f, 316.6f, 323.3f, 330};
	private static readonly float[] grndSuperCoinXPos = { 35.5f, 43.5f, 49, 101.25f, 125, 133, 159,
		163, 165, 167, 169, 173, 247.5f, 252.5f, 280, 290, 300, 310 , 320};

	private const float LOW_FLT_COIN_Y = 3;
	private static readonly float[] lowFloatCoinsXPos = { 15, 25, 34, 42, 47, 53, 59,  };

	private const float MED_FLT_COIN_Y = 5;
	private static readonly float[] medFloatCoinsXPos = { 65, 151, };

	private const float HIGH_FLT_COIN_Y = 7;
	private static readonly float[] highFloatCoinsXpos = { 81, 91, 100, 108, 115, };

	private const float CEIL_COIN_Y = 7.5f;
	private static readonly float[] ceilCoinsXPos = {153, 155, 157, 159, 161, 163, 167, 169, 171, 
		173, 175, 177, 179, 185, 193, 197, 203, 207, 213, 217, 221,
		226.5f, 230, 235.5f, 242, 247.5f, 252.5f};
	private static readonly float[] ceilSuperCoinXPos = {  };

	/*** DROPPERS ***/
	public GameObject emptyDropperObj;
	public GameObject sawDropperObj;
	public GameObject batteryDropperObj;
	private const float DROPPER_Y = 8.5f; // Default y position for dropper objects.
	private const float DROPPER_Z = -1f;
	private static readonly float[] emptyDropperXPos = { 310 };
	private static readonly float[] sawDropperXPos = { 125, 133, 139, 165, 183, 280, 290, 300,
	320, };
	private static readonly float[] batteryDropperXPos = { 145, 330 };


	/*** GRAVITY ***/
	public GameObject revGravHugeObj;
	public GameObject normGravHugeObj;
	private const float GRAV_Y = 4;
	private static readonly float[] reverseGravXPos = { 159 };
	private static readonly float[] normalGravXPos = { 261 };


	/*** LEVEL END ***/
	public GameObject levelEndObj;
	private const float LVL_END = 450; // Where the player sees the end of level.
	private const float LVL_END_Y = 3.75f; // Default y position for level end objects.

	/*** FRAMERATE ***/
	private const int FRAMERATE = 120; // Default framerate.

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = FRAMERATE;
	
	//	addBackground ();
		addGround ();
		addCeiling ();

		/* Small ceiling obstacles. */
		addArray (smallCeilObstaclesXPos, SML_CEIL_OBS_Y, CEIL_OBS_Z, ud_spike);

		/* Medium ceiling obstacles. */
		addArray (medCeilObstaclesXPos, MED_CEIL_OBS_Y, CEIL_OBS_Z, ud_tall_spike);

		/* Add ground obstacles. */
		addGroundObstacles ();

		/* Add coins. */
		addCoins ();

		/* Ground batteries. */
		addArray (grndBatXPos, GRND_BAT_Y, DEFAULT_Z, battery);

		/* Empty droppers. */
		addArray (emptyDropperXPos, DROPPER_Y, DROPPER_Z, emptyDropperObj);

		/* Saw droppers. */
		addArray (sawDropperXPos, DROPPER_Y, DROPPER_Z, sawDropperObj);


		/* Batter droppers. */
		addArray (batteryDropperXPos, DROPPER_Y, DROPPER_Z, batteryDropperObj);

		/* Reverse gravity. */
		addArray (reverseGravXPos, GRAV_Y, DEFAULT_Z, revGravHugeObj);

		/* Normal gravity. */
		addArray (normalGravXPos, GRAV_Y, DEFAULT_Z, normGravHugeObj);

		/* Level end. */
		addEntry (LVL_END, LVL_END_Y, DEFAULT_Z, levelEndObj);

		/* Update the level with all added objects. */
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
		//float width = groundObj.GetComponent<BoxCollider2D> ().size.x;
		//int num_objects = (int) (LVL_LENGTH / width);
		for (int i = (int) START_X; i < LVL_LENGTH; i++) {
			addEntry (i, GRND_Y, DEFAULT_Z, groundObj);
		}
	}

	private void addCeiling () {
		//float width = ceiling.GetComponent<BoxCollider2D> ().size.x;
		//int num_objects = (int)(LVL_LENGTH / width);
		for (float i = START_X; i < CAVE_MIX_BEGIN; i++) {
			addEntry (i, CEIL_Y, DEFAULT_Z, ceiling);
		}

		for (float i = CAVE_MIX_BEGIN; i < CAVE_TOTAL_BEGIN; i++) {
			addEntry (i, CEIL_Y, DEFAULT_Z, caveCeilObj);
		}

		//for (f
	}

	/* Adds small, medium, and huge ground obstacles. */
	private void addGroundObstacles () {
		addArray (smallGrndObstaclesXPos, SML_GRND_OBS_Y, GRND_OBS_Z, spike);
		addArray (medGrndObstaclesXPos, MED_GRND_OBS_Y, GRND_OBS_Z, tall_spike);
		addArray (hugeGrndObstaclesXPos, HUGE_GRND_OBS_Y, GRND_OBS_Z, hugeGrndObj);
	}

	/* Adds ground, low floating, medium floating, high floating, ceiling, and
	 * super coins. */
	private void addCoins () {
		addArray (grndCoinsXPos, GRND_COIN_Y, DEFAULT_Z, coin);
		addArray (lowFloatCoinsXPos, LOW_FLT_COIN_Y, DEFAULT_Z, coin);
		addArray (medFloatCoinsXPos, MED_FLT_COIN_Y, DEFAULT_Z, coin);
		addArray (highFloatCoinsXpos, HIGH_FLT_COIN_Y, DEFAULT_Z, coin);
		addArray (ceilCoinsXPos, CEIL_COIN_Y, DEFAULT_Z, coin);
		addArray (grndSuperCoinXPos, GRND_COIN_Y, DEFAULT_Z, superCoinObj);
	}
}
	