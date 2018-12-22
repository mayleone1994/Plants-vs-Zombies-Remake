using UnityEngine;
using System.Collections;

public class SeedHud : MonoBehaviour {
	public AudioClip clip;
	[HideInInspector]
	public GameObject theSeed;
	
	void OnMouseDown(){
		AudioSource.PlayClipAtPoint (clip, Camera.main.transform.position);
		theSeed.gameObject.GetComponent<SeedButton> ().isSelected = false;
		HUDManager.mySeeds.Remove (gameObject);
		HUDManager.CheckPositions ();
		Destroy (gameObject);
	}
}

