using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpanwer : MonoBehaviour {

    public float spawnTime = 3f;
    public int secBeforeFirstSpawn = 5;
    public GameObject zombie;

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
        GameObject zombieCree = Instantiate(zombie, transform.position , transform.rotation);
        zombieCree.SetActive(true);
    }
}
