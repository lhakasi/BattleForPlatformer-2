using System;
using UnityEngine;
using HealthImpact;

[RequireComponent(typeof(Health))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Health Health => _character.Health;
    
    private int MaxHealth => Health.MaxHealth;
    private int CurrentHealth => Health.CurrentHealth;
        
    public event Action HealthChanged;  

    public void ChangeHealth(HealthImpactTypes impactType, int amountOfImpact)
    {
        switch (impactType)
        {
            case HealthImpactTypes.Healing:
                TakeHealing(CurrentHealth, amountOfImpact);
                break;

            case HealthImpactTypes.Damage:
                TakeDamage(CurrentHealth, amountOfImpact);
                break;
        }

        HealthChanged?.Invoke();

        if (CurrentHealth <= 0)
            _character.Die();
    }   

    private void TakeDamage(int currentHealth, int amountOfImpact) =>    
        Health.SetCurrentHealth(Mathf.Clamp(currentHealth -= amountOfImpact, 0, MaxHealth));
    
    private void TakeHealing(int currentHealth, int amountOfImpact) =>    
        Health.SetCurrentHealth(Mathf.Clamp(currentHealth += amountOfImpact, 0, MaxHealth));
}
