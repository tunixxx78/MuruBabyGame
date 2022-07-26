using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField] float cloudMinSize, cloudMaxSize, size;
    [SerializeField] float cloudMinSpeed, cloudMaxSpeed, speed;


    private void Awake()
    {
        size = Random.Range(cloudMinSize, cloudMaxSize);
    }

    private void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        speed = Random.Range(cloudMinSpeed, cloudMaxSpeed);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
