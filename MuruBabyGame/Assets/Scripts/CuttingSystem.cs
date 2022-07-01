using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] objectStates;
    int objectPhase;

    GameManager gameManager;

    private void Awake()
    {
        objectPhase = 0;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = objectStates[objectPhase];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectPhase++;
            GetComponent<SpriteRenderer>().sprite = objectStates[objectPhase];

            if (objectPhase == objectStates.Length - 1)
            {
                Destroy(this.gameObject, 1f);
                gameManager.foodItems.Remove(this.gameObject);
                gameManager.canMove = true;
            }
        }
    }

}
