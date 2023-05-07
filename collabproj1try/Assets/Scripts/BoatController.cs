using UnityEngine;


public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    // private GameObject cameraObject;
    public boatInformation information;
    private float speed;
    public float forceSpeed = 1;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;

    private float horizontal, vertical;
    public float shootingCooldown = 1;
    public float cooldownTimer = 0;
    public Cannon[] cannons;

    public bool canMove = true;

    void Start()
    {
        // cameraObject = GetComponentInChildren<Camera>().gameObject; // not using it for this script at the moment
        speed = maxSpeed;
        information.remainingAmmo = information.Ammo;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(cooldownTimer < shootingCooldown)
            cooldownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cooldownTimer >= shootingCooldown)
            {
                information.remainingAmmo -= 1;
            }

            if (information.remainingAmmo < 0)
            {
                information.remainingAmmo = 0;
            }
            foreach (var cannon in cannons)
            {
                if (information.remainingAmmo > 0 && cooldownTimer >= shootingCooldown)
                {
                    cannon.shoot();
                }
            }
            if(cooldownTimer > shootingCooldown)
                cooldownTimer = 0;
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(0, 0, vertical * forceSpeed);
        }

        rb.transform.Rotate(new Vector3(0, horizontal * maxRotateSpeed, 0));
    }
}
