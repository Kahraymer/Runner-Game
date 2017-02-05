using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    
    private GameObject pc; //Link to the PC

	private float startOfBlock;
	private float endOfBlock;
	private Vector3 blockSize;
	private ArrayList groundBlocks;


	// To be used as a reference for how newly spawned blocks should be
    public GameObject brownprefab;
    

    

	// Use this for initialization
	void Start () {
        pc = GameObject.Find("PC");
		groundBlocks = new ArrayList();

		// Make new ground block
		GameObject newBlock = Instantiate(brownprefab);
		//			Transform g = newBlock.transform;

		// Set the new ground block to be exactly where the example is 
		newBlock.transform.localPosition = brownprefab.transform.position;
		groundBlocks.Add (newBlock);

		startOfBlock = brownprefab.transform.position.x;
		blockSize = GetComponent<BoxCollider2D> ().bounds.size;
		endOfBlock = startOfBlock + blockSize.x;
    }
	
	// Update is called once per frame
	void Update () {
        int offset = 3;//some offset depending on screensize
		Vector3 curPos = pc.transform.position;

		
		// If the pc is within 3 units of the end of the block, make a new block
		// 3 should eventually be replaced with the size of the screen
		if (endOfBlock - curPos.x < (3+offset)) {

			// Make new ground block
			GameObject newBlock = Instantiate(brownprefab);
//			Transform g = newBlock.transform;

			// Set the new ground block to be exactly where the last one left off
			Vector3 pos = new Vector3(endOfBlock, brownprefab.transform.position.y, brownprefab.transform.position.z);
			newBlock.transform.localPosition = pos;
			groundBlocks.Add (newBlock);

			// Removes first block in array if off the screen
			GameObject firstBlock = (GameObject) groundBlocks[0];
			Transform t = firstBlock.transform;
			if (t.position.x + blockSize.x < curPos.x - offset) {
				groundBlocks.RemoveAt (0);
				Destroy (firstBlock);
//				Debug.Log ("Block is out");
			}

//			Debug.Log (groundBlocks.Count);

			// Update local variables
			startOfBlock = pos.x;
			endOfBlock = startOfBlock + blockSize.x;
        } 
	}
}
