using UnityEngine;
using System.Collections;

public class SeedScript : MonoBehaviour {

	public GameObject prefabPlant;
	public AudioSource[] sound;
	private GameObject spritePlant;
	private bool canPlant = true;
	
	void Update () {
	
		if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties> ().price)
			GetComponent<Renderer> ().material.color = Color.gray;
		else
			GetComponent<Renderer> ().material.color = Color.white;
	}

	private void OnMouseDown(){
		var spr = Resources.Load ("Prefabs/Sprite", typeof(GameObject)) as GameObject;
		if (canPlant && (GameManager.cash >= prefabPlant.GetComponent<Properties> ().price)
			&& GameManager.currentPlant == null && !GameManager.shovelEnabled) {
			sound [0].Play ();
			GameManager.currentPlant = prefabPlant;
			GameManager.currentSeed = gameObject;
			spritePlant = (GameObject)Instantiate (spr, transform.position, Quaternion.identity);
		} else if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties> ().price) {

			sound[1].Play();
		}

	}

	public void StartRecharge(){
		canPlant = false;
		Destroy (spritePlant);
		GameManager.currentSeed = null;
		StartCoroutine ("WaitTime");
	}

	private IEnumerator WaitTime(){
		yield return new WaitForSeconds(GameManager.currentPlant.GetComponent<Properties>().timeRecharge);
		canPlant = true;
	}
}
