using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy moves Right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Creating a downwards ray which starts at the position of groundDetection with Raylength
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        //If Ray is colliding with ground Enemy will move right, else will move left
        if(groundInfo.collider == false)
        {
            //If Enemy is moving right and ray doesnt collide then Enemy will move left else it will continue right
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
    }
}
