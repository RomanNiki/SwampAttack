﻿using UnityEngine;

namespace UI
{
    public class HealthBar : Bar
    {
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.HealthChanged += OnValueChanged;
            Slider.value = 1f;
        }

        private void OnDisable()
        {
            _player.HealthChanged -= OnValueChanged;
        }
    }
}