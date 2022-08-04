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
    PlayerInfo playerInfo;

    [SerializeField] int characterIndexNumber;

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

        playerInfo = FindObjectOfType<PlayerInfo>();
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
        
        if(targetPosition.x < this.transform.position.x && ismoving == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (targetPosition.x > this.transform.position.x && ismoving == true)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    private void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if (hit2D.collider.CompareTag("Target") || hit2D.collider.CompareTag("LayoverTarget") || hit2D.collider.CompareTag("SecondaryTarget"))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;

            ismoving = true;

            characterIndexNumber = playerInfo.mySellectedCharacter;

            FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[1].Play();
        }

        
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

        if(collision.gameObject.tag == "LayoverTarget")
        {
            targetIndex = collision.GetComponent<TargetInformation>().targetSceneIndex;

            PlayerPrefs.SetInt("TargetLevelIndex", targetIndex);

            FindObjectOfType<GameSceneManager>().ChangeScene(targetIndex);
        }
    }


}
