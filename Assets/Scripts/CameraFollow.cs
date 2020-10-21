using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.0f;
    public Vector3 offset;
    Vector3 desiredPosition;
    Vector3 smoothedPosition;

    void FixedUpdate()
    {
        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;
    }
}
