using UnityEngine;
using HealthImpact;

[RequireComponent (typeof(Collider2D))]
public class EnemyAttacker : MonoBehaviour
{    
    [SerializeField, Range(0, 100)] private int _damage;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthChanger healthChanger))        
            Attack(healthChanger);        
    }

    private void Attack(HealthChanger player)
    {        
        player.ChangeHealth(HealthImpactTypes.Damage, _damage);
    }
}
