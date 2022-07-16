using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMovement : MonoBehaviour
{
    int targetIndex;
    Rigidbody2D plrRB;
    [SerializeField] float moveSpeed;
    public Vector3 targetPosition;
    bool ismoving = false, isPlayingEngineSound = false;
    [SerializeField] Sprite character, charWithoutPlane, charWithPlane;

    [SerializeField] GameObject enterGamePanel, parentObject, playerAvatar;
    Animator avatarAnimator;

    SFX sFX;

    private void Awake()
    {
        sFX = FindObjectOfType<SFX>();
    }


    private void Start()
    {
        plrRB = GetComponent<Rigidbody2D>();
        avatarAnimator = playerAvatar.GetComponent<Animator>();
        parentObject = GameObject.Find("Canvas");
        enterGamePanel = parentObject.transform.Find("EnterGamePanel").gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && enterGamePanel.activeSelf == false)
        {
            SetTargetPosition();
        }
        if (ismoving)
        {
            character = playerAvatar.GetComponent<SpriteRenderer>().sprite = charWithPlane;
            avatarAnimator.SetBool("IsFlying", true);
            if(isPlayingEngineSound == false)
            {
                sFX.flying.Play();
            }
            isPlayingEngineSound = true;
            MovePlayer();
        }
        if(ismoving == false)
        {
            character = playerAvatar.GetComponent<SpriteRenderer>().sprite = charWithoutPlane;
            sFX.flying.Stop();
            isPlayingEngineSound = false;
            avatarAnimator.SetBool("IsFlying", false);
        }
        
        if(targetPosition.x < this.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;

        ismoving = true;
    }

    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            ismoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            targetIndex = collision.GetComponent<TargetInformation>().targetSceneIndex;

            PlayerPrefs.SetInt("TargetLevelIndex", targetIndex);
            enterGamePanel.SetActive(true);
            
        }
    }


}
