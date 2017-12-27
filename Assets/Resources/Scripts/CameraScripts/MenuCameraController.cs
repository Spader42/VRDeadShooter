using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour {

	public Transform currentMount;
	private float speedFactor = 0.02f;

	private Vector3 offest;

	// Use this for initialization
	void Start () {
		//this.resetCam ();
	}

	// Update is called once per frame
	void LateUpdate () {
		this.resetCam ();
	}

	public void SetMount(Transform newMount) {
		this.currentMount = newMount;
	}

	public void resetCam()
	{
		transform.position = Vector3.Lerp (transform.position, currentMount.position, speedFactor);
		transform.rotation = Quaternion.Slerp (transform.rotation, currentMount.rotation, speedFactor);
	}
}
