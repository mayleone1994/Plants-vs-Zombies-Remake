using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetsRock : MonoBehaviour {

	public GameManager manager;
	public Canvas canvas;
	public AudioClip clip;
	public int seedsToPlay;
	private Image img;

	void Start(){
		img = GetComponent<Image> ();
	}

	void Update(){

		img.color = HUDManager.mySeeds.Count < seedsToPlay ? Color.gray : Color.white;
	}

	public void Click(){
		if (HUDManager.mySeeds.Count == seedsToPlay) {
			AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
			HUDManager.EnableGame();
			manager.gameObject.GetComponent<GameManager>().enabled = true;
			canvas.enabled = false;
		}
	}
}
