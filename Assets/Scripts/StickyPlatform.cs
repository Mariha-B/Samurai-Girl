using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   //if player collides with platform, becomes a child object of platform 
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   // Once Player disconnects with platform, the platform is no longer a parent to player
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);

        }
    }


}
