using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingSystem : MonoBehaviour
{
    [SerializeField] Sprite[] objectStates;
    [SerializeField] float resetTime = 1;
    int objectPhase;
    Animator kniveAnimator;

    GameManager gameManager;
    SFX sFX;

    bool cantCut = false;

    private void Awake()
    {
        objectPhase = 0;
        gameManager = FindObjectOfType<GameManager>();
        sFX = FindObjectOfType<SFX>();
        kniveAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = objectStates[objectPhase];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cantCut == false)
            {
                cantCut = true;
                kniveAnimator.SetTrigger("Cut");
                objectPhase++;
                sFX.chopping.Play();
                GetComponent<SpriteRenderer>().sprite = objectStates[objectPhase];

                StartCoroutine(ResetCuttingAbility());

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

    IEnumerator ResetCuttingAbility()
    {
        yield return new WaitForSeconds(resetTime);
        cantCut = false;
    }

}
