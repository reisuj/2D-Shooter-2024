using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _enemySpawnDelay = 5.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private bool _playerIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_playerIsAlive)
        {
            yield return new WaitForSeconds(_enemySpawnDelay);
            Vector3 spawnPosition = new Vector3(Random.Range(-9.0f, 9.0f), 7.5f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            // Spawn enemy
        }
    }

    public void PlayerDied()
    {
        _playerIsAlive = false;
    }
}
