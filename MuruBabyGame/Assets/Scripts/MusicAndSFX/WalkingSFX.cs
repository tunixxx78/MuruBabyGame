using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WalkingSFX : MonoBehaviour
{
    [SerializeField] AudioSource rightStep, leftStep;

    public void RightStep()
    {
        rightStep.Play();
    }

    public void LeftStep()
    {
        leftStep.Play();
    }
}
