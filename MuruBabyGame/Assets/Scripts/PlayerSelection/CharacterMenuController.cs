using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuController : MonoBehaviour
{

    SFX sFX;
    

    private void Awake()
    {
        sFX = FindObjectOfType<SFX>();
        
    }

    public void OnClickCharacterPick(int whichCharacter)
    {
        
        if (PlayerInfo.pI != null)
        {
            sFX.button.Play();

            PlayerInfo.pI.mySellectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);

            PlayerPrefs.SetInt("GameStatus", 1);

            PlayerInfo.pI.SpawnSellectedPlayer();

        }

    }
}
