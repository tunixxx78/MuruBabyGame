using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canMove = false, canEat = false, isPlayiing = false;
    public List<GameObject> foodItems = new List<GameObject>();

    public GameObject cookingWare, correctForm, panInStove, emptyPlate;

    [SerializeField] Animator panAnimator, readyFoodAnimator;
    [SerializeField] GameObject levelClearedPanel, thermoMeter, heaticonSpawner, panWithFood;

    public int HeatAmount, maxHeat = 13;
    public thermoBar thermoBar;

    PlayerInfo playerInfo;
    SFX sFX;

    private void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        sFX = FindObjectOfType<SFX>();
    }

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
            panInStove.SetActive(false);
            thermoMeter.SetActive(false);
            panWithFood.SetActive(true);
            emptyPlate.SetActive(true);

            canMove = true;

            readyFoodAnimator.SetTrigger("ReadyNotice");

            if (isPlayiing == false)
            {
                FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[7].Play();
                isPlayiing = true;
            }
            
        }

        if (foodItems.Count <= 0)
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panWithFood.SetActive(true);
        }
    }

    public void MoveCookingWare()
    {
        cookingWare.AddComponent<MoveSystemForCookingWare>();
        cookingWare.GetComponent<MoveSystemForCookingWare>().correctFormCookWare = correctForm;
        cookingWare.GetComponent<MoveSystemForCookingWare>().PanInStove = panInStove;
        panAnimator.SetTrigger("PanNotice");

        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[5].Play();
    }

    public void HeatingUpFood()
    {
        thermoMeter.SetActive(true);
        heaticonSpawner.SetActive(true);

        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[6].Play();
    }

    public void CurrentFinale()
    {
        levelClearedPanel.SetActive(true);
        sFX.winning.Play();

        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[9].Play();
    }
}
