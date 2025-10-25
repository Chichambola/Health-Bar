using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = $"{_health.CurrentHealth.ToString()} / {_health.MaxHealth.ToString()}";
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
        _text.text = $"{health.ToString()} / {maxHealth.ToString()}";
    }
}
