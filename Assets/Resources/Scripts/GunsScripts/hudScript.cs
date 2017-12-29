using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudScript : MonoBehaviour {
	private Gun gun;

	private float transparency = 0.6f;

	private Transform HUDHolder;
	private Transform gunObject;

	private TextMesh textCurrentAmmoInMagazine;
	private TextMesh textCurrentAmmo;

	// Use this for initialization
	void Start () {
		this.HUDHolder = this.transform.parent;
		this.gunObject = this.HUDHolder.parent;
		this.gun = this.gunObject.GetComponent<Gun>();
	}
	
	// Update is called once per frame
	void Update () {
		this.textCurrentAmmoInMagazine = transform.GetChild (0).GetComponentInChildren<TextMesh>();
		this.textCurrentAmmoInMagazine.text = this.gun.magazine.ToString ();

		this.textCurrentAmmoInMagazine = transform.GetChild (1).GetComponentInChildren<TextMesh>();
		this.textCurrentAmmoInMagazine.text = this.gun.ammo.ToString ();
	}

	/// <summary>
	/// Updates the transparency.
	/// </summary>
	void UpdateTransparency() {
		Color color = this.gameObject.GetComponent<Renderer> ().material.color;
		color.a = transparency;
		this.gameObject.GetComponent<Renderer> ().material.color = color;
	}
}
