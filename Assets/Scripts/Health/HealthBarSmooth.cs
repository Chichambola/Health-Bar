using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSmooth : Health
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private float _speedDelay;

    private Coroutine _coroutine;

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
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (health == maxHealth || _slider.value == health)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValueSmoothly(health));
    }

    private IEnumerator ChangeValueSmoothly(float health)
    {
        var wait = new WaitForSecondsRealtime(_speedDelay);

        while (_slider.value != health) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _smoothSpeed);

            yield return wait;
        }
    }
}
