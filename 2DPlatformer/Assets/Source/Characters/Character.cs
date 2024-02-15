using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    private Health _health;
    private HealthChanger _healthChanger;

    public Health Health => _health;
    public HealthChanger HealthChanger => _healthChanger;

    public abstract void Die();

    protected void Initialize()
    {
        _health = GetComponent<Health>();
        _healthChanger = GetComponent<HealthChanger>();
    }
}