using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private Enemy _armlessPrefab;
    //[SerializeField] private Enemy _batPrefab;
    //[SerializeField] private Enemy _ratPrefab;
    //[SerializeField] private Enemy _slimePrefab;

    [SerializeField] private Tilemap _groundTiles;

    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _spawnCooldownReductionMultiplier;

    private List<Vector3> _spawnPositions = new();
    
    private float _currentCooldown;
    //private static Enemy[] _enemies;

    private void Start()
    {
        //_enemies = new Enemy[]
        //{
        //    _armlessPrefab,
        //    _batPrefab,
        //    _ratPrefab,
        //    _slimePrefab
        //};
        SetEnemySpawnPositions();
        InvokeRepeating(nameof(HandleGameDifficultyIncrease), 1f, 1f);
    }

    private void Update()
    {
        HandleEnemySpawning();
    }

    private void SetEnemySpawnPositions()
    {
        foreach (Vector3Int position in _groundTiles.cellBounds.allPositionsWithin)
        {
            if (_groundTiles.HasTile(position))
            {
                _spawnPositions.Add(_groundTiles.GetCellCenterWorld(position));
            }
        }
    }

    private void HandleEnemySpawning()
    {
        _currentCooldown -= Time.deltaTime;

        if (_currentCooldown > Time.time)
        {
            return;
        }

        _currentCooldown = Time.time + _spawnCooldown;

        SpawnEnemyToRandomLocation();
    }

    private void SpawnEnemyToRandomLocation()
    {
        //int randomEnemy = Random.Range(0, _enemies.Length);
        //Enemy enemy = _enemies[randomEnemy];

        int randomEnemy = Random.Range(0, ObjectPool.SharedInstance._amountToPool);

        GameObject enemy = ObjectPool.SharedInstance.GetPooledObject(randomEnemy);

        if (enemy != null)
        {
            enemy.transform.SetPositionAndRotation(GetRandomPosition(), Quaternion.identity);
            enemy.SetActive(true);
        }
        //Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)];
    }

    private void HandleGameDifficultyIncrease()
    {
        _spawnCooldown *= _spawnCooldownReductionMultiplier;
    }
}

