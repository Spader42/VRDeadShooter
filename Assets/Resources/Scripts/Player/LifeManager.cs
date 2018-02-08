using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    public GameObject lifeText;
    public Transform gameOverMount;
    public GameObject cameraHolder;
    public GameObject weaponHolder;
    public GameObject ScoreHolder;
    public GameObject ScoreText;
    public GameObject ScoreFinalText;
    public GameObject LifeBar;
    public GameObject FinaleScore;
    public AudioClip zombieHit;
    public AudioSource sourceZombieHit;
    public AudioClip gameOver;
    public AudioSource sourceGameOver;

    // Use this for initialization
    void Start ()
    {
        this.sourceZombieHit = this.gameObject.AddComponent<AudioSource>();
        this.sourceGameOver = this.gameObject.AddComponent<AudioSource>();

        // Stopping caudio from playing on awake
        this.sourceZombieHit.playOnAwake = false;
        this.sourceGameOver.playOnAwake = false;

        // Assigning clips to their source
        this.sourceZombieHit.clip = this.zombieHit;
        this.sourceGameOver.clip = this.gameOver;
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
            sourceGameOver.Play();
            cameraHolder.GetComponent<MenuCameraController>().SetMount(gameOverMount);
            weaponHolder.SetActive(false);
            ScoreHolder.SetActive(false);
            LifeBar.SetActive(false);
            ScoreFinalText.GetComponent<TextMesh>().text = ScoreText.GetComponent<TextMesh>().text;
            FinaleScore.SetActive(true);
            StartCoroutine(loadMenu());
        }
        else
        {
            sourceZombieHit.Play();
        }
    }
    IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("SceneMenu");
    }
}
