using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] cookingPhases;
    int cookingPhase;
    bool cantAdd = false;

    private void Awake()
    {
        cookingPhase = 0;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = cookingPhases[cookingPhase];
    }

    private void Update()
    {
        if (cookingPhase == cookingPhases.Length - 1 && cantAdd == false)
        {
            cantAdd = true;
            FindObjectOfType<GameManager>().MoveCookingWare();
        }
    }

    public void ChangeCookingPhase()
    {
        cookingPhase++;
        GetComponent<SpriteRenderer>().sprite = cookingPhases[cookingPhase];
    }
}
