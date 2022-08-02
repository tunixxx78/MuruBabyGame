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

    private void Awake()
    {
        generalVoices = FindObjectOfType<GeneralVoices>();
    }

    private void Start()
    {
        int randomGame = Random.Range(0, games.Length);
        Instantiate(games[randomGame], gameSpawnPoint.position, Quaternion.identity);
        generalVoices.palapeli.Play();
    }

    private void Update()
    {
        if(puzzlePoints >= 6)
        {
            welldonePanel.SetActive(true);
            if(congratulationVoice == false)
            {
                generalVoices.koottuPalapeli.Play();
                congratulationVoice = true;
            }
            
        }
    }
}
