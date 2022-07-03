using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatIconSpawner : MonoBehaviour
{
    [SerializeField] int numberToSpawn;
    [SerializeField] GameObject quad, heatIcon;

    private void Start()
    {
        SpawnHeatIcons();
    }

    public void SpawnHeatIcons()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(heatIcon, pos, Quaternion.identity);
        }

    }
}
