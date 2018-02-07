using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable {

    public int startingHealth = 3;
    public GameObject hitParticles;
    public GameObject scoreboard;

    private int currentHealth;
    Animator anim;

    void Start()
    {
        currentHealth = startingHealth;
        anim = this.GetComponent<Animator>();
    }

    public void TakingDamageAnimationStopped()
    {
        anim.SetBool("takeDamage", false);
    }

    public void DeadAnimationDone()
    {
        Defeated();
    }

    public void Damage(int damage, Vector3 hitPoint)
    {
        Instantiate(hitParticles, hitPoint, Quaternion.identity);
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            anim.SetBool("dead", true);
            IncreaseScore();
        }
        else
        {
            anim.SetBool("nextDamageGauche", !anim.GetBool("nextDamageGauche"));
            anim.SetBool("takeDamage", true);
        }
        
    }

    private void IncreaseScore()
    {
        int currentScore = int.Parse(scoreboard.GetComponent<TextMesh>().text);
        currentScore += 50;
        scoreboard.GetComponent<TextMesh>().text = Convert.ToString(currentScore);
    }

    void Defeated()
    {
        gameObject.SetActive (false);
    }
    
}