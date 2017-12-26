using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour {

	public GameObject cameraHolder;
	public Transform newMount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick() {
		Debug.Log ("Clcik");
	}

	void OnMouseDown() {
		Debug.Log ("Object Held down");
		MenuCameraController cameraController = cameraHolder.GetComponent<MenuCameraController> ();

		cameraController.SetMount (newMount);
	}
}
