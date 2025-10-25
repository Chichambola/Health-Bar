using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public event Action<float, float> ValueChanged;

    public bool IsAlive => _health > 0;
    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;

    private void OnValidate()
    {
        IsHealthMoreMaxHealth();
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;

        IsHealthMoreMaxHealth();

        ValueChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (IsAlive)
        {
            _health -= damage;

            if (_health < 0)
                _health = 0;

            ValueChanged?.Invoke(_health, _maxHealth);
        }
    }

    private void IsHealthMoreMaxHealth()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}
