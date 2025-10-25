using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private float _damage;

    public event Action <float> DamageDealt;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DealDamage);
    }

    public void DealDamage()
    {
        DamageDealt?.Invoke(_damage);
    }
}
