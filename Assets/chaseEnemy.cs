using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseEnemy : MonoBehaviour
{
    public float speed;
    public float chaseDistance;
    public Animator animator;
    public bool chasing;
    public bool isGrounded;
    public Transform groundDetection;
    public float dist;



    public GameObject Player;
    public BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;

    private Rigidbody2D rb2d;
    public Transform playerTransform;
    private Vector2 startingPosition;

    public float attackRate = 2f;
    float nextAttack = 0f;

    private void Awake()
    {
        startingPosition = transform.position;
        //playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);


        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance && groundInfo.collider == true)
        { //Chase

            if (transform.position.x > playerTransform.position.x)
            {
                animator.SetBool("isChase", true);

                rb2d.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            else if (transform.position.x < playerTransform.position.x)
            {
                //animator.SetBool("isChase", true);
                rb2d.velocity = new Vector2(speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            
            
        }

        else
        { //Stop Chasing
            StopChase();

        }


        Attack();
    }

    public void Attack()
    {
        if (Time.time >= nextAttack)

        {
            if (Vector2.Distance(transform.position, playerTransform.position) < dist)
            {
                //coroutine to delay attack for 1 second
                nextAttack = Time.time + 6f / attackRate;
                
                animator.SetTrigger("Attack");

                Player.GetComponent<Health>().TakeDamage(1);
                
            }

        }



    }

    public void StopChase()
    {
        animator.SetBool("isChase", false);
        rb2d.velocity = new Vector2(0, 0);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * chaseDistance * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * chaseDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * dist * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * dist, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}