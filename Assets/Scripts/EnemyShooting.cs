using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireballPos;
    private GameObject player;
    [SerializeField] private float range;
    public Animator animator;
    private EnemyPatrol enemyPatrol;
    [SerializeField] private AudioSource shootSound;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private float timer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       //if the player is within range and is alive, enemy shoots
        if(PlayerInSight() == true && player.GetComponent<Health>().currentHealth > 0)
        {
           
            timer += Time.deltaTime;

            if(timer>0.7)
            {   //plays attack animation
                animator.SetTrigger("RangedAttack");
                timer = 0;
                shoot();
            }
            
        }
        if (enemyPatrol != null)
                enemyPatrol.enabled = !PlayerInSight();
    }

    void shoot()
    {   //Plays sound and creates fireball
        shootSound.Play();
        Instantiate(fireball, fireballPos.position, Quaternion.identity);
    }

    private bool PlayerInSight()
    {   //Find player within range of box set
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
