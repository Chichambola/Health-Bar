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
    public float Value => _health;
    public float MaxValue => _maxHealth;

    private void OnValidate()
    {
        IsHealthMoreMaxHealth();
    }

    public void Heal(float healAmount)
    {
        if(healAmount > 0)
        {
            _health += healAmount;

            IsHealthMoreMaxHealth();

            ValueChanged?.Invoke(_health, _maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsAlive && damage > 0)
        {
            _health -= damage;

            if (_health < 0)
                _health = 0;

            ValueChanged?.Invoke(_health, _maxHealth);
        }
    }

    protected virtual void SetHealth(float health, float maxHealth) {  }

    private void IsHealthMoreMaxHealth()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}
