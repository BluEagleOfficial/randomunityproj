using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private float speed;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;

    private float horizontal, vertical;

    void Start()
    {
        speed = maxSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(rb.velocity.x, rb.velocity.y, vertical * speed * 25);
        }

        rb.transform.Rotate(new Vector3(0, horizontal * maxRotateSpeed, 0));
    }
}
