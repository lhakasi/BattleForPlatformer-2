using UnityEngine;

public class Enemy : Character, IMovable
{
    [SerializeField, Range(0, 3)] private float _speed;       

    private IMover _mover;

    public float Speed => _speed;
    public Transform Transform => transform;  
    
    private void Awake() => Initialize();

    private void Update() => _mover?.Move(Time.deltaTime);

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    public override void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("Мишка помер T_T");
    }
}