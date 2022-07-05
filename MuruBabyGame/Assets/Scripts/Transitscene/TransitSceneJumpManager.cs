using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitSceneJumpManager : MonoBehaviour
{
    TransitSceneMovement transitSceneMovement;

    private void Start()
    {
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
