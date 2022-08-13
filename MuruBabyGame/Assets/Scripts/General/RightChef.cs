using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightChef : MonoBehaviour
{
    [SerializeField] Sprite[] chefFaces;
    [SerializeField] int plrIndex;
    [SerializeField] GameObject face, taimiHat, generalHat;

    private void Awake()
    {
        plrIndex = PlayerInfo.pI.mySellectedCharacter;

    }

    private void Start()
    {
        face.GetComponent<Image>().sprite = chefFaces[plrIndex];

        if(plrIndex == 1)
        {
            taimiHat.SetActive(true);
            generalHat.SetActive(false);
        }
        else
        {
            taimiHat.SetActive(false);
            generalHat.SetActive(true);
        }
    }
}
