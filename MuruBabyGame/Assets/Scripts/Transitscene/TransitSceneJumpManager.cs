using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitSceneJumpManager : MonoBehaviour
{
    TransitSceneMovement transitSceneMovement;
    GeneralVoices generalVoices;

    private void Awake()
    {
        generalVoices = FindObjectOfType<GeneralVoices>();
    }

    private void Start()
    {
        generalVoices.keraa.Play();
        Invoke("startShit", .01f);
    }

    void startShit()
    {
        transitSceneMovement = FindObjectOfType<TransitSceneMovement>();
    }

    public void JumpNow()
    {
        transitSceneMovement.Jump();
    }
}
