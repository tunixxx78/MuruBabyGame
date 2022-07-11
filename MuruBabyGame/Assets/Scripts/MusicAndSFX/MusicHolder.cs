using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHolder : MonoBehaviour
{
    [SerializeField] AudioSource[] currenMusic;
    public int musicIndex;

    private void Awake()
    {
        musicIndex = PlayerPrefs.GetInt("TargetLevelIndex") - 3;
    }

    private void Start()
    {
        currenMusic[musicIndex].enabled = true;
    }

}
