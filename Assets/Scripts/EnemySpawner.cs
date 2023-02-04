using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemyList;
    [SerializeField] private float maxSpawnRadius;
    [SerializeField] private float minSpawnRadius;
    [SerializeField] private float spawnTime;

    private int[] randomizers = new int[] { -1, 1 };
    private Vector3 _spawnPosition;
    private GameObject _enemyToBeSpawned;

    private void Start()
    {
        StartCoroutine(Timer());
    }
    private void SpawnController()
    {
        SetSpawnPosition();
        EnemyChoser();
        EnemyInstantiator();
    }
    private void SetSpawnPosition()
    {
        _spawnPosition = new Vector3(Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)], 0, Random.Range(0f, 1f) * randomizers[Random.Range(0, randomizers.Length)]).normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
    }
    private void EnemyChoser() 
    {
        int a = Random.Range(0, EnemyList.Length);
        _enemyToBeSpawned = EnemyList[a];
    }
    private void EnemyInstantiator()
    {
        GameObject enemy = _enemyToBeSpawned;
        Vector3 position = _spawnPosition;
        Instantiate(enemy, position, Quaternion.identity);
    }
    IEnumerator Timer()
    {
        while (true)
        {
            SpawnController();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
