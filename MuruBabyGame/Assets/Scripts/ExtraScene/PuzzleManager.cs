using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int puzzlePoints;
    public GameObject welldonePanel;
    public GameObject[] games;
    bool congratulationVoice = false;

    [SerializeField] Transform gameSpawnPoint;
    GeneralVoices generalVoices;

    PlayerInfo playerInfo;

    private void Awake()
    {
        generalVoices = FindObjectOfType<GeneralVoices>();
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    private void Start()
    {
        playerInfo.characterVoices[0] = GameObject.Find("AlvarVoices").GetComponent<AudioSource>();
        playerInfo.characterVoices[1] = GameObject.Find("TaimiVoices").GetComponent<AudioSource>();

        int randomGame = Random.Range(0, games.Length);
        Instantiate(games[randomGame], gameSpawnPoint.position, Quaternion.identity);
        //generalVoices.palapeli.Play();

        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[10].Play();
    }

    private void Update()
    {
        if(puzzlePoints >= 6)
        {
            welldonePanel.SetActive(true);
            if(congratulationVoice == false)
            {
                //generalVoices.koottuPalapeli.Play();
                FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[11].Play();
                congratulationVoice = true;
            }
            
        }
    }
}
