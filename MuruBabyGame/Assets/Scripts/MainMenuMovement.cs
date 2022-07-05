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
    bool ismoving = false;

    [SerializeField] GameObject enterGamePanel, parentObject;
    

    private void Start()
    {
        plrRB = GetComponent<Rigidbody2D>();
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
            MovePlayer();
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
