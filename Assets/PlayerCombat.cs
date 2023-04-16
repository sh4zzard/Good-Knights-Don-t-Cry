using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float atttackRate = 2f;
    float nextAttackTime = 0f;
    

    void Update()
    {
        if(Time.time >= nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / atttackRate;
            } 
        }
  
    }

    void Attack()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {   
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void OnDrawnGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
