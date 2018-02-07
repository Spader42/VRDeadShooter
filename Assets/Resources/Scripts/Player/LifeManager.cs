using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public GameObject lifeText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(int damage) {
       int life = int.Parse(lifeText.GetComponent<TextMesh>().text);
        life -= damage;
        lifeText.GetComponent<TextMesh>().text = life.ToString();
    }
}
