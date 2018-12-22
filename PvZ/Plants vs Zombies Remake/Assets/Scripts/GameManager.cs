using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject spriteObject, zombie, prefabSun;
	public Vector2 pointSun;
	public AudioSource sound_music, sound_zombie;
	public static GameObject currentPlant, currentSeed, currentSprite;
	public static bool shovelEnabled;
	public static int cash;
	private float[] Y = {2.65f, 1.3f, -0.03f, -1.45f, -2.83f};

	void Start () {
		sound_music.Play ();
		StartCoroutine ("PlaySound");
		InvokeRepeating ("ZombieInstantiate", 2, 10);
		InvokeRepeating ("SunInstantiate", 10, 20);
		shovelEnabled = false;
		currentSprite = spriteObject;
		cash = 50;
		pointSun = new Vector2 (-5.6f, 0.04f);
	}

	void ZombieInstantiate(){
		int order = Random.Range (0, Y.Length);
	GameObject zombieLocal = (GameObject) 
			Instantiate(zombie, new Vector2 (transform.position.x, Y [order]), Quaternion.identity);
		zombieLocal.GetComponent<SpriteRenderer> ().sortingOrder = order + 1;
	}

	void SunInstantiate(){

	GameObject sun = (GameObject)Instantiate (prefabSun, pointSun, Quaternion.identity);
		sun.GetComponent<SunScript> ().myType = "GameManagerInstance";
	}

	IEnumerator PlaySound(){
		yield return new WaitForSeconds(17);
		sound_zombie.Play ();
	}
}
