using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour {

	public GameObject cameraHolder;
	public Transform newMount;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (OVRInput.GetDown(OVRInput.Button.Any)) {
			Debug.Log ("Clicked");
			this.cameraHolder.GetComponent<MenuCameraController> ().SetMount (newMount);
		}
	}

	void ChangeCameraMount() {

		this.cameraHolder.GetComponent<MenuCameraController> ().SetMount (newMount);
	}

	void OnClick() {
		Debug.Log ("What");
	}
}
