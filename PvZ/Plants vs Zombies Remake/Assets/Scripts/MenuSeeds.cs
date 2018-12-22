using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MenuSeeds : MonoBehaviour {
	public GameObject seedPrefab;
	private bool isSelected = false;
	private float seedX;
	private GameObject prefabSeed;
	private const float x = -5.634206f, y = 0.03999996f;

	void OnMouseDown(){
		if (!isSelected){
			isSelected = true;
			seedX = ManagerSeed.seedPosition.Count == 0 ? x : 
				ManagerSeed.seedPosition.Last() + ManagerSeed.distanceX + 0.3f;
			prefabSeed = Instantiate(seedPrefab, new Vector3(seedX, y, 0), Quaternion.identity) as GameObject;
			ManagerSeed.seedPosition.Add(prefabSeed.transform.position.x);
		}
	}
}
