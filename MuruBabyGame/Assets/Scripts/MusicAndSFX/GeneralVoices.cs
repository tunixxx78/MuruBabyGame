using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVoices : MonoBehaviour
{
    public AudioSource aloitetaan, eteenpain, keraa;

    public void AloitetaanButton()
    {
        aloitetaan.Play();
    }
}
