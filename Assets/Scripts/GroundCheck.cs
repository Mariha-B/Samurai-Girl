using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Creating a downwards ray which starts at the position of groundDetection with Raylength
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);

        //If Ray is colliding with ground Enemy will move right, else will move left
        if(groundInfo.collider == false)
        {
            GetComponent<chaseEnemy>().StopChase();

        }

    }
}
