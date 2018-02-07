using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    public GameObject lifeText;
    public Transform gameOverMount;
    public GameObject cameraHolder;

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
        if (life <= 0)
        {
            cameraHolder.GetComponent<MenuCameraController>().SetMount(gameOverMount);
            StartCoroutine(loadMenu());
        }
    }
    IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SceneMenu");
    }
}
