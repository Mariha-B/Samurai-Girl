using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator animator;
    public int attackDamage = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }


    void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in the range of attack
        Collider2D[]   hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage Enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
