using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAudio : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource gemSound;
    [SerializeField] private AudioSource valueSound;
    [SerializeField] private AudioSource healthSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Obj with player tag collides with player, increases Score
        if (collision.tag == "Coin")
        {
            coinSound.Play();

        }

        if (collision.tag == "Gem")
        {
            gemSound.Play();

        }

        if (collision.tag == "Valuable")
        {
            valueSound.Play();

        }

        if (collision.tag == "Collectable")
        {
            healthSound.Play();

        }
    }
}
