using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canMove = false;
    public List<GameObject> foodItems = new List<GameObject>();

    public GameObject cookingWare, correctForm, panInStove;

    [SerializeField] GameObject levelClearedPanel, thermoMeter, heaticonSpawner;

    public int HeatAmount, maxHeat = 13;
    public thermoBar thermoBar;

    private void Start()
    {
        canMove = true;
        HeatAmount = 3;
        thermoBar.SetMaxTemperature(maxHeat);
        thermoBar.SetTemperature(HeatAmount);
        
    }

    private void Update()
    {
        thermoBar.SetTemperature(HeatAmount);

        if (HeatAmount >= maxHeat)
        {
            heaticonSpawner.SetActive(false);
            CurrentFinale();
        }

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

    public void HeatingUpFood()
    {
        thermoMeter.SetActive(true);
        heaticonSpawner.SetActive(true);
    }

    public void CurrentFinale()
    {
        levelClearedPanel.SetActive(true);
    }
}
