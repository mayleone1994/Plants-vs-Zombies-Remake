using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour {
	public int life, timeRecharge, price;
	public AudioClip sound, death;

	private void Update(){
		Death ();

		if (GetComponent<Collider2D> ().OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition)))
			OnMouseDown ();
	}

	private void Death(){
		if (life <= 0) {
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
		}
	}


	private void OnMouseDown(){
		if (GameManager.shovelEnabled && Input.GetMouseButtonDown(0)) {
			AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
			GameManager.shovelEnabled = false;
			Destroy(gameObject);
		}
	}
}
