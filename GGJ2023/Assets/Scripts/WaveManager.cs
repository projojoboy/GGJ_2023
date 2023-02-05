using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int CurrentWave { get; private set; }

    public float spawnDelayTime = 1;

    public List<GameObject> enemies;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyPrefab2;

    [SerializeField]
    private Transform[] _spawnPoints;

    private int _spawnEnemyAmount;
    private int _spawnEnemy2Amount;

    private float _spawnDelayTimer = 0;

    public void NextWave()
    {
        CurrentWave++;

        _spawnDelayTimer = spawnDelayTime;
        _spawnEnemyAmount = 0;
        _spawnEnemy2Amount = 0;

        switch (CurrentWave)
        {
            case 1:

                SpawnEnemy(2, 4);

                break;

            case 2:

                SpawnEnemy(2, 6);

                break;

            case 3:

                SpawnEnemy(2, 10);

                break;

            case 4:

                SpawnEnemy(1, 2);

                break;

            case 5:

                SpawnEnemy(1, 1);
                SpawnEnemy(1, 4);

                break;

            case 6:

                SpawnEnemy(1, 2);
                SpawnEnemy(1, 8);

                break;

            case 7:

                SpawnEnemy(1, 5);

                break;

            case 8:

                SpawnEnemy(1, 3);
                SpawnEnemy(2, 10);

                break;

            case 9:

                SpawnEnemy(2, 20);

                break;

            case 10:

                SpawnEnemy(1, 6);
                SpawnEnemy(2, 20);

                break;

            default:

                SpawnEnemy(1, 8);
                SpawnEnemy(2, 17);

                break;
        }
    }

    public void SpawnEnemy(int index, int amount)
    {
        switch (index)
        {
            case 1:

                _spawnEnemyAmount += amount;

                break;

            case 2:

                _spawnEnemy2Amount += amount;

                break;
        }
    }

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (_spawnDelayTimer > 0)
        {
            _spawnDelayTimer -= Time.deltaTime;
        }
        else
        {
            if (_spawnEnemyAmount <= 0 && _spawnEnemy2Amount <= 0)
                return;

            int randomEnemyType = 1;

            if (_spawnEnemyAmount > 0 && _spawnEnemyAmount > 0)
                randomEnemyType = Random.Range(1, 3);
            else if (_spawnEnemyAmount > 0)
                randomEnemyType = 1;
            else if (_spawnEnemy2Amount > 0)
                randomEnemyType = 2;

            switch (randomEnemyType)
            {
                case 1:

                    if (_spawnEnemyAmount > 0)
                    {
                        InstantiateEnemy(_enemyPrefab, GetRandomSpawnPoint().position);

                        _spawnEnemyAmount--;
                    }

                    break;

                case 2:

                    if (_spawnEnemy2Amount > 0)
                    {
                        InstantiateEnemy(_enemyPrefab2, GetRandomSpawnPoint().position);

                        _spawnEnemy2Amount--;
                    }

                    break;
            }

            _spawnDelayTimer = spawnDelayTime;
        }

        if (
            _spawnEnemyAmount <= 0 &&
            _spawnEnemy2Amount <= 0 &&
            enemies.Count <= 0
        )
            NextWave();
    }

    private void InstantiateEnemy(GameObject enemyPrefab, Vector3 spawnPosition)
    {
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        enemies.Add(enemyObject);

        enemyObject.GetComponent<Health>().OnDeath.AddListener(delegate { OnEnemyDeath(enemyObject); });
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[randomIndex];
    }
}