using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 4f, -8f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    private CameraRotate camRotate;

    [SerializeField] private Transform target;

    void Start()
    {
        if(target == null)
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(cam == null)
            cam = GetComponent<Camera>();
        if(camRotate == null)
            camRotate = GetComponentInParent<CameraRotate>();
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
