using UnityEngine;
using UnityEngine.UI;

public abstract class HealthVisualizer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthChanger _healthChanger;
    
    protected int MaxHealth => _health.MaxHealth;
    protected int CurrentHealth => _health.CurrentHealth;

    private void OnEnable() => _healthChanger.HealthChanged += OnHealthChanged;

    private void OnDisable() => _healthChanger.HealthChanged -= OnHealthChanged;
    
    protected abstract void OnHealthChanged();

    protected void UpdateSliderValues(Slider slider)
    {
        slider.maxValue = MaxHealth;
        slider.value = CurrentHealth;
    }
}