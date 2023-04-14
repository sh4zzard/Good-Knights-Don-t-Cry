using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour 
{
    public int maxHealth = 1;
    int currentHealth;
    public int bossIndicator = 0;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("dmg taken");

        if(currentHealth <= 0)
        {
            Debug.Log("Enemy died");

            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            if(bossIndicator == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
             else
            {
                Destroy(gameObject);
            }
        }
    }
}
