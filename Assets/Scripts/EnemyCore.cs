using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyCore : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int _currentHealth;

    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackCooldown = 2f;
    private float _timer = 0f;

    [SerializeField] private Transform player;
    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
                _currentHealth = 0;
                // Die();
            }
        }
    }

    private int AttackDamage => attackDamage;

    private float AttackCooldown => attackCooldown;
}