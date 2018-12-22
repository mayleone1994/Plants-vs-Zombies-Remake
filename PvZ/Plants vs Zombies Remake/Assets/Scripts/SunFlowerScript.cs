using UnityEngine;
using System.Collections;

public class SunFlowerScript : MonoBehaviour {

	public GameObject sun;

	void Start () {
	
		InvokeRepeating ("SunInstantiate", 5, 20);
	}

	private void SunInstantiate(){

		Instantiate (sun, transform.position, Quaternion.identity);
	}
}
