using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHeatIcon : MonoBehaviour
{
    HeatIconSpawner heatIconSpawner;
    GameManager gameManager;
    Rigidbody2D iconRB;
    [SerializeField] float moveSpeed;

    private void Awake()
    {
        heatIconSpawner = FindObjectOfType<HeatIconSpawner>();
        gameManager = FindObjectOfType<GameManager>();
        iconRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HeatIsUp();
        MoveIcon();

        if (this.gameObject.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
            heatIconSpawner.SpawnHeatIcons();
        }
        if (gameManager.HeatAmount >= gameManager.maxHeat)
        {
            Destroy(this.gameObject);
        }

    }

    private void MoveIcon()
    {
        iconRB.AddForce(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void HeatIsUp()
    {
        if (Input.GetMouseButtonDown(0) && this.gameObject.activeSelf == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("HeatIcon"))
            {
                heatIconSpawner.SpawnHeatIcons();
                gameManager.HeatAmount++;
                Destroy(hit2D.collider.gameObject);
            }
            else { return; }
        }
    }
}
