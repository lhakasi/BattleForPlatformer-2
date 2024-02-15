using AnimationStates;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;

    private float _delayToCompleteAnimation;


    public bool IsAnimationComplete;
    private float AnimationFullLenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void StartAnimation(States state)
    {
        IsAnimationComplete = false;

        _animator.Play(state.ToString());

        _delayToCompleteAnimation = Time.time + AnimationFullLenght;
    }

    public void Flip(Vector3 velocity)
    {
        if (velocity.x > 0)
            _sprite.flipX = true;

        if (velocity.x < 0)
            _sprite.flipX = false;
    }

    public void Update()
    {
        if (Time.time >= _delayToCompleteAnimation)
            IsAnimationComplete = true;
    }
}

namespace AnimationStates
{
    public enum States
    {
        Idle,
        Walk,
        Jump,
        Attack,
        Hurt,
        Die
    }
}