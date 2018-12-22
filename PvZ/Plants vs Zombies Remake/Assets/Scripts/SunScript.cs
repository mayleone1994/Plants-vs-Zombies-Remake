using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	public AudioClip audioPlay;
	[HideInInspector]
	public string myType;

	private enum States {Collected, noCollected};
	private States myStates;
	private Vector2 target;

	void Start(){
		target = new Vector2 (-3.4f, 3.5f);
		myStates = States.noCollected;
		Destroy (gameObject, 10);
	}
		
	void FixedUpdate(){
		if (myType == "GameManagerInstance" && myStates == States.noCollected)
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -15 * Time.deltaTime);
	}

	void Update(){
		if (myStates == States.noCollected) {
			if (GetComponent<CircleCollider2D> ().OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition)))
				MouseClick ();
		} else if (myStates == States.Collected){
			transform.position = Vector2.MoveTowards(transform.position, target, 6*Time.deltaTime);
			if (transform.position.x == target.x && transform.position.y == target.y)
				Destroy(gameObject);
		}
	}

	void MouseClick(){
		if (Input.GetMouseButtonDown (0)) {
			myStates = States.Collected;
			GameManager.cash += 25;
			AudioSource.PlayClipAtPoint (audioPlay, Camera.main.transform.position);
		}
	}
}
