using UnityEngine;

namespace Enemy.StateMachine.Transitions
{
    [RequireComponent(typeof(Enemy))]
    public class DeathTransition : Transition
    {
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _enemy.Dying += OnDeath;
        }

        private void OnDeath(Enemy enemy)
        {
            NeedTransit = true;
            enemy.Dying -= OnDeath;
        }
    }
}