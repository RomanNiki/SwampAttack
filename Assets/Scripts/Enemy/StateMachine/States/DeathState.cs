using UnityEngine;

namespace Enemy.StateMachine.States
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public class DeathState : State
    {
        [SerializeField] private float _timeToDestroy;
        private Collider2D _collider;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _animator.Play("Death");
            _collider.enabled = false;
            Destroy(gameObject, _timeToDestroy);
        }

        private void OnDisable()
        {
            _collider.enabled = true;
            _animator.StopPlayback();
        }
    }
}