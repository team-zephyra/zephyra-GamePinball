using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject trapPrefab;

    public static int coinSpawned;
    public static int trapSpawned;
    private int maxCoinSpawned = 3;
    private int maxTrapSpawned = 3;
    private float startDelay = 3f;
    private float spawnInterval = 3f;
    private Vector3 boxSize = new Vector3(1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        coinSpawned = 0;
        trapSpawned = 0;
        InvokeRepeating("SpawnCoin", startDelay, spawnInterval);
        InvokeRepeating("SpawnTrap", startDelay, spawnInterval);
    }

    private void SpawnCoin()
    {
        if (coinSpawned < maxCoinSpawned)
        {
            Vector3 spawnLocation = GetRandomSpawnCoinLocation();

            if (spawnLocation != Vector3.zero)
            {
                Instantiate(coinPrefab, spawnLocation, coinPrefab.transform.rotation);
                coinSpawned++;
            }
        }
    }

    private void SpawnTrap()
    {
        if (trapSpawned < maxTrapSpawned)
        {
            Vector3 spawnLocation = GetRandomSpawnTrapLocation();

            if (spawnLocation != Vector3.zero)
            {
                Instantiate(trapPrefab, spawnLocation, trapPrefab.transform.rotation);
                trapSpawned++;
            }
        }
    }

    private Vector3 GetRandomSpawnCoinLocation()
    {
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-7f, 5f), 1f, Random.Range(-4f, -1f));

            if (!Physics.BoxCast(spawnLocation, boxSize * 0.5f, Vector3.up, Quaternion.identity, 0f))
            {
                return spawnLocation;
            }
        }

        return Vector3.zero;
    }

    private Vector3 GetRandomSpawnTrapLocation()
    {
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-7f, 5f), 0.5f, Random.Range(-4f, -1f));

            if (!Physics.BoxCast(spawnLocation, boxSize * 0.5f, Vector3.up, Quaternion.identity, 0f))
            {
                return spawnLocation;
            }
        }

        return Vector3.zero;
    }
}
