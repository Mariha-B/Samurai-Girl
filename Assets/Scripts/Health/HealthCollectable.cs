using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Obj with player tag collides with player, increases Health
        if(collision.tag == "Player" && collision.GetComponent<Health>().currentHealth < 3 )
        {
            collision.GetComponent<Health>().AddHealth(healthValue) ;
            gameObject.SetActive(false);
        }
    }
}
