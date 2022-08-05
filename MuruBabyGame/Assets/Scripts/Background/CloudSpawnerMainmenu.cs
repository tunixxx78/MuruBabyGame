using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerMainmenu : MonoBehaviour
{
    [SerializeField] GameObject[] cloudPrefab;
    [SerializeField] GameObject cloudInstance;
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
            int cloud = Random.Range(0, cloudPrefab.Length);

            cloudInstance = Instantiate(cloudPrefab[cloud], cloudSpawnPoints[i].position, Quaternion.identity);
            Destroy(cloudInstance, 30f);
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
