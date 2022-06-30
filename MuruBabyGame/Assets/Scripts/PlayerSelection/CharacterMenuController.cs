using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuController : MonoBehaviour
{
   public void OnClickCharacterPick(int whichCharacter)
    {
        if (PlayerInfo.pI != null)
        {
            PlayerInfo.pI.mySellectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);

            PlayerInfo.pI.SpawnSellectedPlayer();
        }
    }
}
