using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour {
	public bool isEmpty = true;

	private void OnMouseDown(){
		if (GameManager.currentPlant != null && isEmpty) {
			Instantiate(GameManager.currentPlant, transform.position, Quaternion.identity);
			GameManager.currentSeed.GetComponent<SeedScript>().StartRecharge();
			GameManager.cash -= GameManager.currentPlant.GetComponent<Properties>().price;
			GameManager.currentPlant = null;
		}
	}

	void Update(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up, 0.1f, LayerMask.GetMask("Plants"));
		isEmpty = hit.collider == null;
	}
}
