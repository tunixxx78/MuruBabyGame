using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] cookingPhases;
    int cookingPhase;
    bool cantAdd = false;

    GameManager gameManager;
    SFX sFX;

    private void Awake()
    {
        cookingPhase = 0;
        gameManager = FindObjectOfType<GameManager>();
        sFX = FindObjectOfType<SFX>();
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
            //gameManager.CurrentFinale();
            StartCoroutine(LoopIsOver(1));
        }
    }

    public void ChangeCookingPhase()
    {
        sFX.eating.Play();
        cookingPhase++;
        GetComponent<SpriteRenderer>().sprite = cookingPhases[cookingPhase];
    }

    IEnumerator LoopIsOver(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameManager.CurrentFinale();
    }
}
