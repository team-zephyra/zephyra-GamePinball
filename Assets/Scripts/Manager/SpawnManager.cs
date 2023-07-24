using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;

    public static int coinSpawned;
    private int maxCoinSpawned = 3;
    private float startDelay = 3f;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawned = 0;
        InvokeRepeating("SpawnCoin", startDelay, spawnInterval);
    }

    private void SpawnCoin()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-7f, 5f), 1f, (Random.Range(-4f, -1f)));

        if (coinSpawned < maxCoinSpawned)
        {
            Instantiate(coinPrefab, spawnLocation, coinPrefab.transform.rotation);
            coinSpawned++;
        }
    }
}
