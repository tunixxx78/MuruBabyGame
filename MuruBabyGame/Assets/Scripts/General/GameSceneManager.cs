using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject sceneOutPanel;
    public float animationDuration;

    AudioSource music;
    SFX sFX;
    GeneralVoices generalVoices;
    [SerializeField] float currentVolume, startVolume, wantedVolume;

    

    public int gameStatus;

    private void Awake()
    {
        Screen.SetResolution(2688, 1242, true);
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        sFX = FindObjectOfType<SFX>();
        generalVoices = FindObjectOfType<GeneralVoices>();
        currentVolume = 0;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            gameStatus = 0;
            PlayerPrefs.SetInt("GameStatus", gameStatus);
        }
        else
        {
            gameStatus = PlayerPrefs.GetInt("GameStatus");
        }
        
    }

    private void Start()
    {
        currentVolume = music.volume;
        StartCoroutine(FadeMusicOn());
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex != 0)
        {
            FindObjectOfType<PlayerInfo>().hasStarted = false;
        }
        
    }

    public void ChangeScene(int sceneIndex)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 0)
        {
            generalVoices.eteenpain.Play();
        }
            
        sFX.button.Play();
        StartCoroutine(ScangeSceneNow(sceneIndex));
        sceneOutPanel.SetActive(true);
    }

    public void StartFadeMusicOff()
    {
        StartCoroutine(FadeMusicOff());
    }

    IEnumerator ScangeSceneNow(int targetIndex)
    {
        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(targetIndex);
    }
    IEnumerator FadeMusicOn()
    {
        startVolume = 0;
        currentVolume = 0;

        while(currentVolume < wantedVolume)
        {
            currentVolume = currentVolume + 0.2f * Time.deltaTime;
            music.volume = currentVolume;

            yield return null;
        }
    }

    IEnumerator FadeMusicOff()
    {
        startVolume = music.volume;
        currentVolume = music.volume;

        while(currentVolume > 0)
        {
            currentVolume = currentVolume - 0.25f * Time.deltaTime;
            music.volume = currentVolume;

            yield return null;
        }

        music.Stop();
        music.volume = startVolume;
    }
}
