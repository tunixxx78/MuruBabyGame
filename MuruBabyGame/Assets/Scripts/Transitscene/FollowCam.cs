using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f, followSpeed = 10f;
    [SerializeField] Vector3 offset;
    static float cameraY = 3.3f, minX, maxX;
    [SerializeField] Transform worldEdgeRight, worldEdgeLeft;
    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        /*float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        minX = worldEdgeLeft.position.x + width;
        maxX = worldEdgeRight.position.x - width;
        transform.position = GetWantedPosition();
        cameraY = transform.position.y;*/

        Invoke("StartShit", .01f);
    }

    void StartShit()
    {
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        minX = worldEdgeLeft.position.x + width;
        maxX = worldEdgeRight.position.x - width;
        transform.position = GetWantedPosition();
        cameraY = transform.position.y;
    }

    Vector3 GetWantedPosition(bool followY = true)
    {
        float x = Mathf.Clamp(target.position.x + offset.x, minX, maxX);
        float y = followY ? target.position.y + offset.y : transform.position.y;

        if (!followY && cameraY != -3.3f)
        {
            y = cameraY;
        }

        return new Vector3(x, y, -10f);
    }

    private void LateUpdate()
    {
        Vector3 wantedPosition = GetWantedPosition(false);

        transform.position = Vector3.SmoothDamp(transform.position, wantedPosition, ref velocity, followSpeed);
    }
}
