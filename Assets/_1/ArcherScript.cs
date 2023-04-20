using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 10f;
    public float attackDelay = 2f;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public LayerMask playerLayer;
    private int currentHealth = 10;

    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;
    private bool isFacingRight = true;
    private float attackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check if player is within attack range
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= attackRange)
        {
            // Update attack timer
            attackTimer += Time.deltaTime;

            // Attack player if enough time has passed
            if (attackTimer >= attackDelay)
            {
                Attack();
                attackTimer = 0f;
            }
        }

        // Flip the archer to face the player
        if (player.transform.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move towards player
        rb.velocity = new Vector2((player.transform.position - transform.position).normalized.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        // Flip the archer's sprite and facing direction
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Attack()
    {
        // Shoot an arrow at the player
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - arrowSpawnPoint.position).normalized;
        arrow.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Archer got dmg");

        if(currentHealth <= 0)
        {
            Debug.Log("Enemy died");
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject);
            }
    }
}
