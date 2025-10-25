using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = _health.CurrentHealth;
        _slider.maxValue = _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.ValueChanged += SetHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= SetHealth;
    }

    private void SetHealth(float health, float maxHealth)
    {
       _slider.value = health;
       _slider.maxValue = maxHealth;
    }
}
