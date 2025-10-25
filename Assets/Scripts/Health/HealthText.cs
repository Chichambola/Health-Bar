using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : Health
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = $"{Value} / {MaxValue}";
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
        _text.text = $"{health.ToString()} / {maxHealth.ToString()}";
    }
}
