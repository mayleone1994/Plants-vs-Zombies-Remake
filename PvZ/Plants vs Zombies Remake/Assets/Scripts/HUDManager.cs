using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour {
	
	public static List<GameObject> mySeeds = new List<GameObject>();

	void Start(){
		GetComponent<GameManager> ().enabled = false;
	}
	
	public static Vector2 GeneratePosition(){
		if (mySeeds.Count == 0) 
			return new Vector2 (-2.7f, 3.9f);
		var positionX = mySeeds [0].gameObject.GetComponent<SpriteRenderer> ().bounds.size.x + 
			mySeeds [mySeeds.Count - 1].transform.position.x + 0.06f; ;
		return new Vector2 (positionX, 3.9f);
		
	}
	
	public static void CheckPositions(){
		if (mySeeds.Count > 0) {
			for (int i = 0; i < mySeeds.Count; i++) {
				mySeeds [i].transform.position = i == 0 ? new Vector2 (-2.7f, 3.9f) : 
					new Vector2 (mySeeds [0].gameObject.GetComponent<SpriteRenderer> ().bounds.size.x +
					             mySeeds [i - 1].transform.position.x + 0.06f, 3.9f);
			}
		} else 
			return;
	}

	public static void EnableGame(){
		foreach (var s in mySeeds) {
			Destroy(s.gameObject.GetComponent<SeedHud>());
			s.gameObject.GetComponent<SeedScript>().enabled = true;
		}
	}
}

