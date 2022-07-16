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

    GameObject sceneChangeOut;
    float animationDuration;

    SFX sFX;

    private void Awake()
    {
        plrRB = GetComponent<Rigidbody2D>();
        followCam = FindObjectOfType<FollowCam>();
        sFX = FindObjectOfType<SFX>();
        
    }

    private void Start()
    {
        targetIndex = PlayerPrefs.GetInt("TargetLevelIndex");
        followCam.target = this.gameObject.transform;

        sceneChangeOut = FindObjectOfType<GameSceneManager>().sceneOutPanel;
        animationDuration = FindObjectOfType<GameSceneManager>().animationDuration;
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
            sceneChangeOut.SetActive(true);

            StartCoroutine(ScangeSceneNow());

            //SceneManager.LoadScene(targetIndex);
        }
        if(collision.gameObject.tag == "Collectible")
        {
            sFX.collecting.Play();
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

    IEnumerator ScangeSceneNow()
    {
        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(targetIndex);
    }
}
