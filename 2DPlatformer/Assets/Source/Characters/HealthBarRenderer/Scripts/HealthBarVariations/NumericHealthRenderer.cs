using TMPro;
using UnityEngine;

public class NumericHealthRenderer : HealthVisualizer
{
    [SerializeField] private TMP_Text _healthBar;

    private void Start() => RenderHealthBar();   

    protected override void OnHealthChanged() => RenderHealthBar();    

    private void RenderHealthBar() => _healthBar.text = $"{CurrentHealth}/{MaxHealth} HP";
}