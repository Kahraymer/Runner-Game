using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour {
	public enum Direction {Normal, Inverted};
	public Direction direction;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (direction == Direction.Normal) {
				other.gameObject.GetComponent<PlayerController> ().Inverted = false;
				other.transform.localScale = new Vector3 (1, 1, 1);
			} else {
				other.gameObject.GetComponent<PlayerController> ().Inverted = true;
				other.transform.localScale = new Vector3 (1, -1, 1);
			}
		}
	}
}
