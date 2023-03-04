using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numCoinsToSpawn = 10;
    public float spawnRadius = 100f;

    private void Start()
    {
        for (int i = 0; i < numCoinsToSpawn; i++)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0f, Random.Range(-spawnRadius, spawnRadius));
            Vector3 spawnPosition = transform.position + randomOffset;

            GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
