using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            _timeAfterLastSpawn = 0f;
        }

        if (_spawned >= _currentWave.Count)
        {
            _currentWave = null;

            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }
        }

        _timeAfterLastSpawn += Time.deltaTime;
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template[Random.Range(0, _currentWave.Template.Count)],
            _spawnPoint.position, Quaternion.identity, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy.Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        _spawned = 0;
        SetWave(_currentWaveNumber++);
    }
}

[Serializable]
public class Wave
{
    public List<Enemy.Enemy> Template;
    public float Delay;
    public int Count;
}