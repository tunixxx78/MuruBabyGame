using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightChef : MonoBehaviour
{
    [SerializeField] Sprite[] chefFaces;
    [SerializeField] int plrIndex;
    [SerializeField] GameObject face;

    private void Awake()
    {
        plrIndex = PlayerInfo.pI.mySellectedCharacter;

    }

    private void Start()
    {
        face.GetComponent<Image>().sprite = chefFaces[plrIndex];
    }
}
