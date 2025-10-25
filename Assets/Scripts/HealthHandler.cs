using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private HealButton _healButton;
    [SerializeField] private DamageButton _damageButton;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _healButton.Healed += _health.Heal;
        _damageButton.DamageDealt += _health.TakeDamage;
    }

    private void OnDisable()
    {
        _healButton.Healed -= _health.Heal;
        _damageButton.DamageDealt -= _health.TakeDamage;
    }
}
