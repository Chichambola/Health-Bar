using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] protected Health Health;
    [SerializeField] private float Value;

    protected void Awake()
    {
        Button = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClicked);
    }

    protected void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ApplyValue(Value);
    }

    protected abstract void ApplyValue(float amount);
}
