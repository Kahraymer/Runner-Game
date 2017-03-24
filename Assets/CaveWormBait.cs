using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWormBait : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player")
			SendMessageUpwards ("PopOutOfGround");
	}
}
