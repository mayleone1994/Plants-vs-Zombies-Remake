using UnityEngine;
using System.Collections;

public class SpriteFollow : MonoBehaviour {

	public Sprite spriteShovel;
	void Start () {

		if (GameManager.currentPlant == null) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load("Sprites/General/Shovel", typeof(Sprite)) as Sprite;
			GetComponent<SpriteRenderer> ().sortingOrder = 7;
		} else {
			GetComponent<SpriteRenderer> ().sprite = GameManager.currentPlant.GetComponent<SpriteRenderer> ().sprite;
		}
	}

    void Update(){

		Vector3 mouseP = Input.mousePosition;
		mouseP.z = transform.position.z - Camera.main.transform.position.z;
		transform.position = Camera.main.ScreenToWorldPoint(mouseP);

		if (GameManager.currentPlant == null && !GameManager.shovelEnabled)
			Destroy (gameObject);
	}
}

