using UnityEngine;
using System.Collections;

public class ShovelScriptHud : MonoBehaviour {

	public AudioClip clip;

	private void OnMouseDown(){
		if (GameManager.currentPlant == null && !GameManager.shovelEnabled) {
			AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
			GameManager.shovelEnabled = true;
			Instantiate(GameManager.currentSprite, transform.position, Quaternion.identity);
		}
	}
}
