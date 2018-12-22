using UnityEngine;
using System.Collections;

public class GrassInstantiate : MonoBehaviour {
	
	public GameObject prefabGrass;
	private GameObject grass;
	private float currentX = -4.811f, currentY = 2.347f;
	private bool newLine = true;
	
	void Start(){
		float distanceX = prefabGrass.GetComponent<SpriteRenderer> ().bounds.size.x;
		float distanceY = prefabGrass.GetComponent<SpriteRenderer> ().bounds.size.y;

		for (int i = 0; i < 45; i++){
			if (i % 9 == 0 && i != 0){
				newLine = true;
				currentY = grass.transform.position.y - distanceY;
			}
			if (newLine){
				grass = Instantiate(prefabGrass, new Vector2(-4.811f, currentY), Quaternion.identity) as GameObject;
				newLine = false;
			} else {
				grass = Instantiate(prefabGrass, new Vector2(currentX, currentY), Quaternion.identity) as GameObject;
			}
			currentX = grass.transform.position.x + distanceX;
			grass.transform.SetParent(transform);
		}
	}
}

