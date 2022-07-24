using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVoices : MonoBehaviour
{
    public AudioSource aloitetaan;

    public void AloitetaanButton()
    {
        aloitetaan.Play();
    }
}
