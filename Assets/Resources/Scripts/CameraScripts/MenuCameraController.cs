using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour {

	public Transform currentMount;
	private float speedFactor = 0.02f;
    public float speedFactorE = 0.0f;
    public float speedRotation = 0.0f;

	private Vector3 offest;

	// Use this for initialization
	void Start () {
		//this.resetCam ();
        if(speedFactorE != 0.0f)
        {
            speedFactor = speedFactorE;
        }
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
        if(speedRotation == 0.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedRotation);
        }
	}
}
