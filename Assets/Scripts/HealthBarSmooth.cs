using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSmooth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed;

    private Coroutine _coroutine;

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
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (health == maxHealth || _slider.value == health)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValueSmoothly(health));
    }

    private IEnumerator ChangeValueSmoothly(float health)
    {
        var wait = new WaitForSecondsRealtime(0.05f);

        while (_slider.value != health) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _smoothSpeed);

            yield return wait;
        }
    }
}
