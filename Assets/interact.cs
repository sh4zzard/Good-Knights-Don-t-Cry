using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour
{
    public float delay = 3f;
    private Animator            m_animator;
    private bool rdytodie = false;
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            Debug.Log("rdy");
            rdytodie = true;    
        }       
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            rdytodie = false;
        }
    }
    void Update()
    {
        if (rdytodie && Input.GetKeyDown(KeyCode.F))
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
