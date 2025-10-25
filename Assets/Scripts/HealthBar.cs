using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : Health
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = Value;
        _slider.maxValue = MaxValue;
    }

    private void OnEnable()
    {
        ValueChanged += SetHealth;
    }

    private void OnDisable()
    {
        ValueChanged -= SetHealth;
    }

    protected override void SetHealth(float health, float maxHealth)
    {
       _slider.value = health;
       _slider.maxValue = maxHealth;
    }
}
