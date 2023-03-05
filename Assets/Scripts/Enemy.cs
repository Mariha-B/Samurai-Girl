using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Hurt Animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Die Animation
        Debug.Log("Enemy Died");

        animator.SetBool("isDead", true);
        //Destroy Enemy
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;


        Destroy(gameObject, 1.3f);

    }

   
}
