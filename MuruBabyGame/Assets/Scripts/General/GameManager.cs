using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canMove = false;
    public List<GameObject> foodItems = new List<GameObject>();

    [SerializeField] GameObject levelClearedPanel;

    private void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        if (foodItems.Count <= 0)
        {
            levelClearedPanel.SetActive(true);
        }
    }
}
