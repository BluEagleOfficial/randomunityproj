using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 4f, -8f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
