using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private GameObject cameraObject;

    private float speed;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;

    private float horizontal, vertical;

    void Start()
    {
        cameraObject = GetComponentInChildren<Camera>().gameObject;
        speed = maxSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // if (rb.velocity.magnitude < maxSpeed)
        // {
        //     rb.AddRelativeForce(0, 0, vertical * speed * 25);
        // }
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, vertical * speed);

        rb.transform.Rotate(new Vector3(0, horizontal * maxRotateSpeed, 0));
        // Vector3 rot = new Vector3(rb.transform.rotation.x, rb.transform.rotation.y + horizontal, rb.transform.rotation.z);
        // rb.transform.rotation = Vector3.MoveTowards(rb.transform.rotation, rot, Time.deltaTime * maxRotateSpeed);
    }
}
