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
    

    private void Start()
    {
        plrRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        
    }

    private void SetTargetPosition()
    {
        //targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.x = 2;
        targetPosition.y = 4;
        targetPosition.z = 0;
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            targetIndex = collision.GetComponent<TargetInformation>().targetSceneIndex;

            SceneManager.LoadScene(targetIndex);
        }
    }
}
