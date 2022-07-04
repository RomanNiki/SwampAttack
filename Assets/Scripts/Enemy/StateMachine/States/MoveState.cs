﻿using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class MoveState : State
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            if (Target == null)
            {
                return;
            }
            
            transform.position =
                Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }
}