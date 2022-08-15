using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCharacter : MonoBehaviour
{
    GameSceneManager gameSceneManager;

    [SerializeField] float reloadDelay;

    private void Awake()
    {
        gameSceneManager = FindObjectOfType<GameSceneManager>();
        reloadDelay = gameSceneManager.animationDuration;
    }

    public void ChangePlayerCharacter()
    {
        gameSceneManager.gameStatus = 0;
        PlayerPrefs.SetInt("GameStatus", 0);

        gameSceneManager.sceneOutPanel.SetActive(true);
        gameSceneManager.StartFadeMusicOff();
        StartCoroutine(ReloadScene(reloadDelay));

        
    }
    IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(1);
    }
}
