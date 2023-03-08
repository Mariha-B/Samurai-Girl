using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator animator;
    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage,0, startingHealth);
        if(currentHealth > 0)
        {
            //Player Hurt
            //animator.SetTrigger("Hurt");
            GetComponent<SpriteFlash>().Flash();
        }
        else 
        { 
        //Player Dead

        }
    }
   public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }
}
