using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable {

    public int startingHealth = 3;
    public GameObject scoreboard;
    public GameObject magnum;
    public GameObject ak47;
    public GameObject pompe;

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
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            int bonus = UnityEngine.Random.Range(0, 3);
            int random = UnityEngine.Random.Range(0, 2);
            int bonusAmmo = 0;
            if (bonus == 0)
            {
                bonusAmmo = UnityEngine.Random.Range(1, 2);
            }
            if (random == 0)
            {
                magnum.GetComponent<Gun>().ammo += 2 + bonusAmmo;
                
            }
            else if (random == 1)
            {
                ak47.GetComponent<Gun>().ammo += 4 + bonusAmmo;
            }
            else if (random == 2)
            {
                pompe.GetComponent<Gun>().ammo += 1 + bonusAmmo;
            }
            anim.SetBool("dead", true);
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            Vector3 size;
            size.x = 0;
            size.y = 0;
            size.z = 0;
            boxCollider.size = size;
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