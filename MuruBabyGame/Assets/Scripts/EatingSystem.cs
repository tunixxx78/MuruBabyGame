using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] cookingPhases;
    int cookingPhase;
    bool cantAdd = false;

    GameManager gameManager;

    private void Awake()
    {
        cookingPhase = 0;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = cookingPhases[cookingPhase];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("Plate"))
            {
                ChangeCookingPhase();
            }
            else { return; }
        }

        if (cookingPhase == cookingPhases.Length - 1 && cantAdd == false)
        {
            cantAdd = true;
            gameManager.CurrentFinale();
        }
    }

    public void ChangeCookingPhase()
    {
        cookingPhase++;
        GetComponent<SpriteRenderer>().sprite = cookingPhases[cookingPhase];
    }

}
