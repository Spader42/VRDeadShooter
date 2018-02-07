using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpanwer : MonoBehaviour {

    public float spawnTime = 3f;
    public int secBeforeFirstSpawn = 5;
    public int nbKillForDifficultyToUp = 10;
    public int chanceThatAZombieDontSpawn = 10;
    public int speedZombieMin = 10;
    public int speedZombieMax = 30;
    public GameObject zombie;
    public GameObject scoreboard;

	// Use this for initialization
	void Start () {
        StartCoroutine(DelayBeforeSpawn());
	}

    IEnumerator DelayBeforeSpawn()
    {
        yield return new WaitForSeconds(secBeforeFirstSpawn);
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Spawn()
    {
        int currentScore = int.Parse(scoreboard.GetComponent<TextMesh>().text);
        int nbZombieKilled = currentScore / 50;
        int difficulty = nbZombieKilled / nbKillForDifficultyToUp;

        if (chanceThatAZombieDontSpawn > difficulty)
        {
            int random = Random.Range(0, (chanceThatAZombieDontSpawn - difficulty));
            if (random != 0)
            {
                return;
            }
        }
        GameObject zombieCree = Instantiate(zombie, transform.position , transform.rotation);
        zombieCree.GetComponent<MovingIntoCamera>().speed = 
            Random.Range(speedZombieMin, speedZombieMax);
        zombieCree.SetActive(true);
    }
}
