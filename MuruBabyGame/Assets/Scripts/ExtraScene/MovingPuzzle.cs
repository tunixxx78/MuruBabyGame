using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzle : MonoBehaviour
{
    [SerializeField] GameObject correctForm;
    [SerializeField] bool moving, onPos;
    float startPosX, startPosY;

    Vector3 resetPosition;

    PuzzleManager puzzleManager;
    SFX sFX;

    private void Awake()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        sFX = FindObjectOfType<SFX>();
    }

    private void Start()
    {
        resetPosition = this.transform.localPosition;
        puzzleManager.puzzlePoints = 0;
    }

    private void Update()
    {
        if(onPos == false)
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
        if (Input.GetMouseButtonDown(0))
        {
            sFX.pickingThings.Play();
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <=  1.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            if(onPos == false)
            {
                sFX.pickingThings.Play();
                puzzleManager.puzzlePoints++;
            }
            
            onPos = true;
            
        }
        else
        {
            this.transform.position = resetPosition;
        }
    }


}
