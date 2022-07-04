using UnityEngine;

namespace Enemy.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _defaultState;
        
        private Player _target;
        private State _currentState;

        public State CurrentState => _currentState;

        private void Start()
        {
            _target = GetComponent<Enemy>().Target;
            ResetState(_defaultState);
        }

        private void Update()
        {
            if (_currentState == null) return;

            var next = _currentState.GetNext();
            if (next != null)
            {
                Transit(next);
            }
        }

        private void ResetState(State startState)
        {
            _currentState = startState;

            if (_currentState != null)
            {
                _currentState.Enter(_target);
            }
        }

        private void Transit(State nextState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            
            _currentState = nextState;

            if (nextState != null)
            {
                _currentState.Enter(_target);
            }
        }
    }
}
