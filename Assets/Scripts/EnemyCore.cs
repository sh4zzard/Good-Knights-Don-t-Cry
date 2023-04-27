using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyCore : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int _currentHealth;

    [SerializeField] private int attackDamage = 2;

    [SerializeField] private float attackCooldown = 2f;

    //TODO remove
    private float _timer = 0f;

    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    private Transform _player;

    [SerializeField] private DebugPanel dp;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        dp = GetComponent<DebugPanel>();

        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("[" + gameObject + "] dmg taken");
        _currentHealth -= damage;
    }

    private void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }

    // Properties zone
    private int MaxHealth => maxHealth;

    private int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > _currentHealth)
            {
                Debug.Log(gameObject + " died");
                _currentHealth = 0;
                Die();
            }
        }
    }

    private int AttackDamage => attackDamage;

    private float AttackCooldown => attackCooldown;
}