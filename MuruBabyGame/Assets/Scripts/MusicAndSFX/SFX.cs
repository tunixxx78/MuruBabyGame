using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX : MonoBehaviour
{
    public AudioSource button, KitchenAmbient, frying, flying, chopping, collecting, eating;

    public void ButtonSound()
    {
        button.Play();
    }
}
