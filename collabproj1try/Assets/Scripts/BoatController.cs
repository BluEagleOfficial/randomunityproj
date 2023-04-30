using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private float speed;
    public float maxSpeed = 10;

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
        rb.velocity = new Vector3(-horizontal * speed, rb.velocity.y, -vertical * speed);
    }
}
