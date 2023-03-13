using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    public GameObject winMenu;
    public GameObject valuable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Obj with player tag collides with player, Ends Level
        if (collision.tag == "Player" && valuable.activeSelf== false)
        {
            
            winMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
