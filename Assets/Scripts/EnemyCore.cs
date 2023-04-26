using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
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
            if (value <= 0)
            {
                _currentHealth = 0;
                // Die();
            }
        }
    }

    private int AttackDamage => attackDamage;

    private float AttackCooldown => attackCooldown;
}