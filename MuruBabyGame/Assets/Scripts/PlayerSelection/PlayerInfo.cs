using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //For character selection functions.
    public static PlayerInfo pI;
    public int mySellectedCharacter;
    public GameObject[] allCharacters;

    [SerializeField] Transform plrSpawnPosition;
    [SerializeField] GameObject plrSelectionPanel;

    private void OnEnable()
    {
        if (PlayerInfo.pI == null)
        {
            PlayerInfo.pI = this;
        }
        else
        {
            if (PlayerInfo.pI != this)
            {
                Destroy(PlayerInfo.pI.gameObject);
                PlayerInfo.pI = this;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySellectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySellectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySellectedCharacter);
        }
    }

    public void SpawnSellectedPlayer()
    {
        Instantiate(allCharacters[mySellectedCharacter], plrSpawnPosition.position, Quaternion.identity);
        plrSelectionPanel.SetActive(false);
    }
}
