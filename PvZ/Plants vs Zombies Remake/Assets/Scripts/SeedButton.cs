using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour {
	public AudioClip clip;
	public GameObject prefabSeed;
	[HideInInspector]
	public bool isSelected = false;
	private GameObject seed;
	private Image img;
	
	void Start(){
		
		img = GetComponent<Image> ();
	}
	
	void Update(){
		
		img.color = isSelected ? Color.gray : Color.white;
	}
	
	public void Click(){
		if (!isSelected) {
			AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
			isSelected = true;
			seed = Instantiate(prefabSeed, HUDManager.GeneratePosition(), Quaternion.identity) as GameObject;
			HUDManager.mySeeds.Add(seed);
			seed.gameObject.GetComponent<SeedHud>().theSeed = gameObject;
		}
	}
	
}
