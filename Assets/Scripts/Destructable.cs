using System;
using Unity.VisualScripting;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1;
    [SerializeField] private float currentHealth = 1;
    [SerializeField] private float _cooldown = .25f;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsDead => currentHealth <= 0;

    public void ApplyDamage(float damage)
    {
        if (_cooldown > 0 || IsDead) { return; }
        _cooldown = .25f;
        currentHealth -= damage;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (IsDead)
        {
            currentHealth = 0;
            gameObject.BroadcastMessage("OnDeath");
        }
    }

    public void SetMaxHealth(float value)
    {
        maxHealth = value;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }
}
