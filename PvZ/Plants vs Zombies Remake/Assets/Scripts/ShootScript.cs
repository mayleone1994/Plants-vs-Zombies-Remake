using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
	public AudioClip sound;
	public float damageHit, velocity;
	public bool isIce;

	void Start(){

		Destroy (gameObject, 3.2f);
	}

	void FixedUpdate () {
	
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity*Time.deltaTime, 0);
	}

	private void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject != null && other.gameObject.tag == "Zombie"){
			if(isIce){
				other.GetComponent<ZombieScript>().WalkSlow();
			}
			AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
			other.GetComponent<ZombieScript>().zombieLife -= damageHit;
			Destroy(gameObject);
		}
	}
}
