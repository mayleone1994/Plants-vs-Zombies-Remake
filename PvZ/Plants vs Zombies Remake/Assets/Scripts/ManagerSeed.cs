using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerSeed : MonoBehaviour {

	public static List<float> seedPosition;
	public static string currentClick;
	public static bool isMenu = true;
	public static float distanceX;
	
	void Start(){
		var spriteWidth = Resources.Load("Prefabs/SunFlowerSeed", typeof(GameObject)) as GameObject;
		distanceX = spriteWidth.GetComponent<SpriteRenderer> ().bounds.size.x;
	}

	void Update(){

		if (!isMenu)
			gameObject.SetActive (false);
	}
}
