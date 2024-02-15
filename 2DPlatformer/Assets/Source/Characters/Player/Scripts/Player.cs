using AnimationStates;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Character
{
    [field: SerializeField] public PlayerView View { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker { get; private set; }
    [field: SerializeField] public AttackZone AttackZone { get; private set; }
    [field: SerializeField] public CoinCollector CoinCollector { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public PlayerConfig Config { get; private set; }

    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;

    public PlayerInput Input => _input;

    private void Awake()
    {
        Initialize();

        _input = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public override void Die()
    {
        View.StartAnimation(States.Die);

        gameObject.SetActive(false);

        Debug.Log("онлеп");
    }
}