using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TCashText : MonoBehaviour {

	public GUIStyle style;
	public float X = 80, Y = 23;

	void OnGUI(){
		GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new 
		                           Vector3( Screen.width / 1220.0f, Screen.height / 881.0f, 1.0f ) );
		GUI.Label (new Rect (X, Y, 50, 100), GameManager.cash.ToString (), style);
	}
}
