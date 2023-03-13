using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
      [SerializeField] private int coinValue;
      

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //If Obj with player tag collides with player, increases Score
            if (collision.tag == "Player")
            {
                
                collision.GetComponent<ScoreManager>().AddScore(coinValue);
                
                
                gameObject.SetActive(false);
            }
        }
}

