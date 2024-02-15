using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HealthVisualizer
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private Slider _slider;

    private void Awake() =>  _slider = GetComponent<Slider>();

    private void Start()
    {
        UpdateSliderValues(_slider);

        _fill.color = _gradient.Evaluate(1f);
    }

    protected override void OnHealthChanged()
    {
        UpdateSliderValues(_slider);

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
