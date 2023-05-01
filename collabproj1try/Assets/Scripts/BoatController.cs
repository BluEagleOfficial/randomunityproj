using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    // private GameObject cameraObject;

    private float speed;
    public float forceSpeed = 1;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;

    private float horizontal, vertical;

    public Cannon cannon;

    public bool canMove = true;

    void Start()
    {
        // cameraObject = GetComponentInChildren<Camera>().gameObject; // not using it for this script at the moment
        speed = maxSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cannon.shoot();
        }
    }

    void FixedUpdate()
    {
        if(!canMove)
            return;
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(0, 0, vertical * forceSpeed);
        }

        rb.transform.Rotate(new Vector3(0, horizontal * maxRotateSpeed, 0));
    }
}
