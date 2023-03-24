using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject GameOver;

    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator animator;
    [SerializeField] AudioSource gameOversound;
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

            //Player Flashes
            GetComponent<SpriteFlash>().Flash();
        }
        else 
        {
            //Player Dead
            animator.SetTrigger("Die");
            StartCoroutine(Delay(1.3f));
             gameOversound.Play();

        }
    }
   public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }

    private IEnumerator Delay(float dur)
    {
        //Delays GameOver screen so Death animation can play
        GetComponent<PlayerMovement>().speed = 0;
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(dur);
        gameObject.SetActive(false);
        GameOver.SetActive(true);
       
        Time.timeScale = 0f;


    }


}
