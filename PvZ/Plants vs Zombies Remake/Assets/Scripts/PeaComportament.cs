using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeaComportament : MonoBehaviour {

	public GameObject pea;
	private float distanceX;
	private int layer;
	
	void Start(){
		layer = LayerMask.GetMask ("Zombies");
		distanceX = 6.09f - transform.position.x;
		InvokeRepeating ("Shoot", 0, 2);
	}

	private void Shoot(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right, distanceX, layer);
		if (hit.collider != null) {
			Instantiate(pea, transform.position, Quaternion.identity);
		}
	}
}
	
