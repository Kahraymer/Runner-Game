using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelM1 : WorldBaseM {

    public GameObject greendirt;
    public GameObject column;
    private int column_y = 4;


	// Use this for initialization
	void Start () {
      //  pc = Instantiate( Quaternion.identity)
        addGround();
        addColumns();
        levelObjects.Add(makeWorldEntry(new Vector3(30, 2, 0), column));
        WorldUpdate();
    }

    private void addGround () {
        for (int i = 0; i < 250; i++) {
            levelObjects.Add(makeWorldEntry(new Vector3(i, 0, 0), greendirt));
        }
    }

    private void addColumns () {
        for (int i = 0; i < 250; i++) {
            if (i % 10 == 0) {
                levelObjects.Add(makeWorldEntry(new Vector3(i, column_y, 0), column));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		WorldUpdate ();
	}
}
