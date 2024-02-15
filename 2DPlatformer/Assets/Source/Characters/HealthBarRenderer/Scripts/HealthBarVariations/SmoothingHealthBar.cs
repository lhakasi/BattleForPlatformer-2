using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothingHealthBar : HealthVisualizer
{    
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _delay;
    [SerializeField] private float _interpolationValue = 1;    

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake() =>  _slider = GetComponent<Slider>();

    private void Start()
    {
        UpdateSliderValues(_slider);

        _fill.color = _gradient.Evaluate(1f);
    }

    protected override void OnHealthChanged()
    {
        _slider.maxValue = MaxHealth;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealthSlider());
    }

    private IEnumerator ChangeHealthSlider()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_slider.value != CurrentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, CurrentHealth, _interpolationValue);

            _fill.color = _gradient.Evaluate(_slider.normalizedValue);

            yield return delay;
        }
    }
}