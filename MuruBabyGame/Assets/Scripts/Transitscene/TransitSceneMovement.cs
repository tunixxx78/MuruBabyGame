using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitSceneMovement : MonoBehaviour
{
    Rigidbody2D plrRB;
    bool isGrounded = false;
    [SerializeField] float MoveSpeed, jumpForce, checkGroundRadius;
    FollowCam followCam;
    int targetIndex;
    [SerializeField] Transform groundPoint;
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        plrRB = GetComponent<Rigidbody2D>();
        followCam = FindObjectOfType<FollowCam>();
        
    }

    private void Start()
    {
        targetIndex = PlayerPrefs.GetInt("TargetLevelIndex");
        followCam.target = this.gameObject.transform;
    }

    private void Update()
    {
        plrRB.AddForce(Vector3.right * MoveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        CheckIfGrounded();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TransitTarget")
        {
            SceneManager.LoadScene(targetIndex);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            plrRB.velocity = new Vector3(plrRB.velocity.y, jumpForce);
        }
        CheckIfGrounded();
        
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundPoint.position, checkGroundRadius, groundLayer);

        if(collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
