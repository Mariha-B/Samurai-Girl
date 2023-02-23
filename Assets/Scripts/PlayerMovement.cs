using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private void Awake()
    {   //Finds the Rigidbody component within Object
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);

        //Flips the Player when going Left and Right
        if(horizontalInput> 0.01f)
        {
            transform.localScale = Vector3.one; 
        }
        else if (horizontalInput < 0.01f)
        { 
            transform.localScale = new Vector3(-1, 1, 1);
        }
            

       
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}