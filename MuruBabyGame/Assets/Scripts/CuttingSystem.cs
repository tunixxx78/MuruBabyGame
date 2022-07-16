using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] objectStates;
    int objectPhase;

    GameManager gameManager;
    SFX sFX;

    private void Awake()
    {
        objectPhase = 0;
        gameManager = FindObjectOfType<GameManager>();
        sFX = FindObjectOfType<SFX>();
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
            sFX.chopping.Play();
            GetComponent<SpriteRenderer>().sprite = objectStates[objectPhase];

            if (objectPhase == objectStates.Length - 1)
            {
                Destroy(this.gameObject, .21f);
                FindObjectOfType<CookingSystem>().ChangeCookingPhase();
                gameManager.foodItems.Remove(this.gameObject);
                gameManager.canMove = true;
            }
        }
    }

}
