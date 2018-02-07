using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelected : MonoBehaviour  {
    public GameObject weaponSwitcher;
    public int weaponId;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void setSelectedWeapon()
    {
        weaponSwitcher.GetComponent<WeaponSwitching>().selectedWeapon = weaponId;
        weaponSwitcher.GetComponent<WeaponSwitching>().SelectWeapon();
    }
}
