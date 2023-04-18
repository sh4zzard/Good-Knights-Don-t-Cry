using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;
    public bool bossIndicator = false;

    // public float speed = 2.5f;
    public float attackRange = 3f;
    // public float visionRange = 8f;

    public Transform attackPoint;
    public LayerMask HKLayers;
    public int attackDamage = 40;

    // public float atttackRate = 2f;
    public float Cooldown = 2f;
    private float timer = 0f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    Collider2D[] hitHK;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("dmg taken");

        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died");

            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            if (bossIndicator == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    //public void EnemyAttacks()
    void Update()
    {
        timer += Time.deltaTime;

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (timer >= Cooldown)
            {
                EnemyAttack();
                timer = 0f;
            }
        }
    }

    void EnemyAttack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitHK = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, HKLayers);

        if (hitHK.Length > 0)
        {
            Collider2D HK = hitHK[0];
            HK.GetComponent<HealthHK>().TakeDamage2(attackDamage);
        }
    }
}