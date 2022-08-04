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

    [SerializeField] Animator avatarAnimator;

    [SerializeField] Sprite[] collectibleBaskets;
    [SerializeField] Sprite concratsBasket;
    
    

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

        avatarAnimator = GetComponentInChildren<Animator>();

        //concratsBasket = GameObject.Find("incridientsBasket").GetComponent<SpriteRenderer>().sprite;
        concratsBasket = collectibleBaskets[targetIndex - 3];

        GameObject.Find("incridientsBasket").GetComponent<SpriteRenderer>().sprite = concratsBasket;
       
    }

    private void Update()
    {
        plrRB.AddForce(Vector3.right * MoveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        if (isGrounded)
        {
            avatarAnimator.SetBool("AlvarRun", true);
        }
        else { avatarAnimator.SetBool("AlvarRun", false); }
        
        CheckIfGrounded();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TransitTarget")
        {
            GameObject.Find("incridientsBasket").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("incridientsBasket").GetComponent<Rigidbody2D>().gravityScale = 1;

            StartCoroutine(StartCloudAnimation());

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
            avatarAnimator.SetTrigger("AlvarJump");
            avatarAnimator.SetBool("AlvarRun", false);
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
    IEnumerator StartCloudAnimation()
    {
        yield return new WaitForSeconds(1);

        sceneChangeOut.SetActive(true);
    }
}
