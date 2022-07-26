using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemHolders;
    public Transform[] spawnpoints;
    public GameObject[] backgrounds;
    [SerializeField] Transform bgSpawnpoint;

    public int holderIndex;

    ItemHolder itemHolder;

    private void Awake()
    {
        holderIndex = PlayerPrefs.GetInt("TargetLevelIndex") - 3;
        itemHolder = itemHolders[holderIndex].GetComponent<ItemHolder>();
    }

    private void Start()
    {
        spawnItems();
        SpawnBackground();
    }

    void spawnItems()
    {
        for(int i = 0; i < spawnpoints.Length; i++)
        {
            int item = Random.Range(0, itemHolder.items.Length);
            Instantiate(itemHolder.items[item], spawnpoints[i].position, Quaternion.identity);
        }
    }

    void SpawnBackground()
    {
        Instantiate(backgrounds[holderIndex], bgSpawnpoint.position, Quaternion.identity);
    }
}
