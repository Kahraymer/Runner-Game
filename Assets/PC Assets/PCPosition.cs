using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// THIS IS AN UNUSED SCRIPT AND SHOULD BE DELETED

public class PCPosition : MonoBehaviour {

    public class pc_object {

    }

    public int pc_x_get() {
        return (int)GetComponent<Transform>().position.x;
    }

    public int pc_y_get () {
        return (int)GetComponent<Transform>().position.y;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
