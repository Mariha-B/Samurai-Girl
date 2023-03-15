using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    public GameObject winMenu;
    public GameObject valuable;
    [SerializeField] private AudioSource winSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Obj with player tag collides with player and has collected the Valuable item, Ends Level
        if (collision.tag == "Player" && valuable.activeSelf== false)
        {
            
            winMenu.SetActive(true);
            winSound.Play();
            Time.timeScale = 0f;
        }
    }
}
