using UnityEngine;

namespace UI
{
    public class ProgressBar : Bar
    {
        [SerializeField] private Spawner _spawner;

        private void OnEnable()
        {
            _spawner.EnemyCountChanged += OnValueChanged;
            Slider.value = 0f;
        }

        private void OnDisable()
        {
            _spawner.EnemyCountChanged -= OnValueChanged;
        }
    }
}