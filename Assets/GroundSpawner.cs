using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    
    private GameObject pc; //Link to the PC
    private int lastpos; //Last position of the PC

    public Transform brownprefab;
    

    

	// Use this for initialization
	void Start () {
        //last_pc_x = pc_x();
        pc = GameObject.Find("PC");
        lastpos = (int) pc.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        //  if (in)
        int offset = 3;//some offset depending on screensize
        int curPos = (int) pc.transform.position.x;
        if (curPos - lastpos > 1) {
           // Debug.Log("cur" + curPos);
            //Debug.Log("last" + lastpos);

 //           Debug.Log("Make Ground.");
            Transform g = (Transform)Instantiate(brownprefab);
           // float x = (float)curPos;
            Vector3 pos = new Vector3(curPos + offset, -1, 0);
            g.localPosition = pos;
            //g.transform.position.Set(curPos, 0, 0);
            //g.transform.position.z = 0;

            lastpos = curPos + offset;
        } 
	}
}
