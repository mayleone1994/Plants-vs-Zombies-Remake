using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	public AudioSource sound;

	void OnMouseDown(){
		if (GameManager.currentSeed != null || GameManager.shovelEnabled) {
			sound.Play();
			GameManager.currentSeed = null;
			GameManager.currentPlant = null;
			GameManager.shovelEnabled = false;
		}
	}
}
