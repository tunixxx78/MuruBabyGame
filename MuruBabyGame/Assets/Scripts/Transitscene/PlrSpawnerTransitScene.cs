using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrSpawnerTransitScene : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    [SerializeField] Transform spawnpoint;
    int plrIndex;

    private void Awake()
    {
        plrIndex = PlayerPrefs.GetInt("MyCharacter");
        Instantiate(characters[plrIndex], spawnpoint.position, Quaternion.identity);
    }

    private void Start()
    {
        
    }
}
