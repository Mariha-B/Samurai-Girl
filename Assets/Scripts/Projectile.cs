using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public Animator animator;
    private float timer;
    public float damage;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot+180);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer> 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))

            {
            
            animator.SetTrigger("Explode");
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject,0.1f);
            }
    }
}
