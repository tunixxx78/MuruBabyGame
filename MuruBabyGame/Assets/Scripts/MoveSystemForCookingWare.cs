using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystemForCookingWare : MonoBehaviour
{
    public GameObject correctFormCookWare, PanInStove;
    bool moving, finnish;
    float startPosX, startPosY;

    Vector3 resetPosition;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        resetPosition = this.transform.localPosition;
        PanInStove.SetActive(false);

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
                correctFormCookWare.SetActive(true);

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
        correctFormCookWare.SetActive(false);

        if (Mathf.Abs(this.transform.localPosition.x - correctFormCookWare.transform.localPosition.x) <= 5f && Mathf.Abs(this.transform.localPosition.y - correctFormCookWare.transform.localPosition.y) <= 5f)
        {
            this.transform.position = new Vector3(correctFormCookWare.transform.position.x, correctFormCookWare.transform.position.y, correctFormCookWare.transform.position.z);

            finnish = true;

            gameManager.canMove = false;
            StartCoroutine(Continue());

            PanInStove.SetActive(true);
            correctFormCookWare.SetActive(false);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;

            

        }

        else
        {
            this.transform.localPosition = resetPosition;
        }
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(3);

        gameManager.HeatingUpFood();
    }
}
