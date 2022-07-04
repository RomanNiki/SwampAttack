using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NextWaveButton : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Button _nextWaveButton;

        private void OnEnable()
        {
            _spawner.AllEnemySpawned += OnAllEnemySpawned;
            _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
        }

        private void OnDisable()
        {
            _spawner.AllEnemySpawned -= OnAllEnemySpawned;
            _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
        }

        private void OnAllEnemySpawned()
        {
            _nextWaveButton.gameObject.SetActive(true);
        }

        private void OnNextWaveButtonClick()
        {
            _spawner.NextWave();
            _nextWaveButton.gameObject.SetActive(false);
        }
    }
}
