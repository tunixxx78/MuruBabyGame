using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] Animator itemAnimator;

    private void Awake()
    {
        itemAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemAnimator.SetTrigger("Collected");
            Destroy(this.gameObject, 1.2f);
        }
    }
}
