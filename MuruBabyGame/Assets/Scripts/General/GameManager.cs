using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canMove = false;
    public List<GameObject> foodItems = new List<GameObject>();

    public GameObject cookingWare, correctForm, panInStove;

    [SerializeField] GameObject levelClearedPanel;

    private void Start()
    {
        canMove = true;
        
    }

    private void Update()
    {
        if (foodItems.Count <= 0)
        {
            
        }
    }

    public void MoveCookingWare()
    {
        cookingWare.AddComponent<MoveSystemForCookingWare>();
        cookingWare.GetComponent<MoveSystemForCookingWare>().correctFormCookWare = correctForm;
        cookingWare.GetComponent<MoveSystemForCookingWare>().PanInStove = panInStove;
    }

    public void CurrentFinale()
    {
        levelClearedPanel.SetActive(true);
    }
}
