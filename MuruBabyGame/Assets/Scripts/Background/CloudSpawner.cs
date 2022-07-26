using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloudPrefab, cloudInstance;
    [SerializeField] Transform[] cloudSpawnPoints;
    [SerializeField] float spawnDelay, minDelay, maxDelay;

    private void Start()
    {
        SpawnClouds();
    }

    void SpawnClouds()
    {
        for (int i = 0; i < cloudSpawnPoints.Length; i++)
        {
            cloudInstance =  Instantiate(cloudPrefab, cloudSpawnPoints[i].position, Quaternion.identity);
            Destroy(cloudInstance, 10f);
        }

        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        spawnDelay = Random.Range(minDelay, maxDelay);

        yield return new WaitForSeconds(spawnDelay);

        SpawnClouds();

    }

    
}
