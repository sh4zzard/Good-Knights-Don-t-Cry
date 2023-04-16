using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHK : MonoBehaviour
{
    public int maxHp = 1;
    int currentHp;
    public int damage = 1;
    public float delay = 3f;
    private Animator            m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        currentHp = maxHp;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log(currentHp);    
            currentHp -= damage;
        }
        if (currentHp <= 0)
        {
            m_animator.SetTrigger("Death");
            Invoke("LoadGameOverScene", delay);    
        }        
    }
    void LoadGameOverScene()
    {
        SceneManager.LoadScene(8);
    }
}
