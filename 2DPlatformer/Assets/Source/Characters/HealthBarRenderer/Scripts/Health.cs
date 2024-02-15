using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake() => CurrentHealth = MaxHealth;

    public void SetMaxHealth(int health) => MaxHealth = health;
    public void SetCurrentHealth(int health) => CurrentHealth = health;
}