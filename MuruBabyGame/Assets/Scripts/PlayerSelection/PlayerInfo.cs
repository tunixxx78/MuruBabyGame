using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //For character selection functions.
    public static PlayerInfo pI;
    public int mySellectedCharacter;
    public GameObject[] allCharacters;
    public AudioSource[] characterVoices;

    [SerializeField] Transform plrSpawnPosition;
    [SerializeField] GameObject plrSelectionPanel;

    public bool hasStarted = false;
    
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
    
    private void Awake()
    {
        characterVoices[0] = GameObject.Find("AlvarVoices").GetComponent<AudioSource>();
        characterVoices[1] = GameObject.Find("TaimiVoices").GetComponent<AudioSource>();

    }

    private void Start()
    {
        

        if (FindObjectOfType<GameSceneManager>().gameStatus == 1)
        {
            plrSelectionPanel.SetActive(false);
            mySellectedCharacter = PlayerPrefs.GetInt("MyCharacter");
            SpawnSellectedPlayer();
        }
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySellectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySellectedCharacter = PlayerPrefs.GetInt("MyCharacter");
            PlayerPrefs.SetInt("MyCharacter", mySellectedCharacter);
        }
    }

    private void Update()
    {
        if (hasStarted == false)
        {
            characterVoices[0] = GameObject.Find("AlvarVoices").GetComponent<AudioSource>();
            characterVoices[1] = GameObject.Find("TaimiVoices").GetComponent<AudioSource>();

            hasStarted = true;
        }
    }

    public void SpawnSellectedPlayer()
    {
        
        Instantiate(allCharacters[mySellectedCharacter], plrSpawnPosition.position, Quaternion.identity);
        plrSelectionPanel.SetActive(false);
        


        characterVoices[mySellectedCharacter].GetComponent<PlrVoices>().voices[0].Play();
        


    }
}
