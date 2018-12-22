using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {
	public float vel, zombieLife;
	public AudioClip clip;
	private bool canWalk, canHit;
	private int layer;
	private Rigidbody2D rb;
	private Animator anim;
	public AudioSource sound;

	void Start(){
		canHit = true;
		layer = LayerMask.GetMask ("Plants");
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update(){

		DetectPlant();
		CheckDeath ();
	}

	void FixedUpdate(){

		rb.velocity = canWalk ? new Vector2 (-vel * Time.deltaTime, 0) : Vector2.zero;
	}

	void DetectPlant(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.right, 0.3f, layer);
		if (hit.collider != null) {
				anim.SetBool("isEating", true);
				canWalk = false;
				if (!sound.isPlaying){
					sound.Play();
				}
				if(canHit)
					StartCoroutine(DelayEat(hit.collider));
		} else {
			sound.Stop();
			anim.SetBool("isEating", false);
			StopCoroutine("DelayEat");
			canWalk = canHit = true;
		}
	}

	IEnumerator DelayEat(Collider2D col){
		canHit = false;
		yield return new WaitForSeconds(2);
		canHit = true;
		if (col != null)
			col.transform.gameObject.GetComponent<Properties> ().life--;
	}

	void CheckDeath(){
		if (zombieLife <= 0)
			Destroy(gameObject);
	}

	public void WalkSlow(){
		StopCoroutine ("WalkFast");
		vel = 1;
		AudioSource.PlayClipAtPoint (clip, Camera.main.transform.position);
		GetComponent<SpriteRenderer> ().material.color = Color.cyan;
		StartCoroutine ("WalkFast");
	}

	IEnumerator WalkFast(){
		yield return new WaitForSeconds(10);
		vel = 6;
		GetComponent<SpriteRenderer> ().material.color = Color.white;
	}

}
