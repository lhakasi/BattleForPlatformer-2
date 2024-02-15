using HealthImpact;
using UnityEngine;

public class PlayerCollisionProcessor : MonoBehaviour
{
    private Player _player;

    private HealthChanger HealthChanger => _player.HealthChanger;
    private CoinCollector CoinCollector => _player.CoinCollector;

    private void Awake() => _player = GetComponent<Player>();    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MedKit medKit))
        {
            HealthChanger.ChangeHealth(HealthImpactTypes.Healing, medKit.HealingEffect);

            medKit.PlayPickSound();
            medKit.TurnOff();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            Debug.Log("Взял монетку");
            CoinCollector.AddCoin();

            coin.PlayPickSound();
            coin.TurnOff();
        }
    }
}
