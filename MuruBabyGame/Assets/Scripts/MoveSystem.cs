using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm, cuttingboardObject;
    bool moving, finnish;

    float startPosX, startPosY;

    Vector3 resetPosition;

    [SerializeField] Transform spawnPoint;

    GameManager gameManager;

    PlayerInfo playerInfo;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();

        //playerInfo.characterVoices[0] = GameObject.Find("AlvarVoices").GetComponent<AudioSource>();
        //playerInfo.characterVoices[1] = GameObject.Find("TaimiVoices").GetComponent<AudioSource>();

        resetPosition = this.transform.localPosition;
        gameManager.foodItems.Add(cuttingboardObject);

        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[4].Play();

    }

    private void Update()
    {
        
        if (finnish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInParent<Animator>().enabled = false;
                correctForm.SetActive(true);
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                moving = true;
            }
        }
        
    }

    private void OnMouseUp()
    {
        moving = false;
        correctForm.SetActive(false);

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);

            finnish = true;

            cuttingboardObject.transform.position = spawnPoint.position;
            cuttingboardObject.SetActive(true);

            gameManager.canMove = false;

            Destroy(correctForm);
            Destroy(this.gameObject);
            
        }

        else
        {
            this.transform.localPosition = resetPosition;
        }
    }
}
