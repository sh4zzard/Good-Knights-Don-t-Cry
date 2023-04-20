using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public int attackDamage = 2;
    private float DestroyTime = 3f;
    private float timer = 0f;
    private bool isFacingRight = true;
    private GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
    }
    public void OnTriggerEnter2D(Collider2D arrow)
    {
        if (arrow.CompareTag("Player"))
        {
            HealthHK HK = arrow.GetComponent<HealthHK>();
            HK.GetComponent<HealthHK>().TakeDamage2(attackDamage);
            Destroy(gameObject);    
        }       
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= DestroyTime)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        // Flip the archer's sprite and facing direction
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
