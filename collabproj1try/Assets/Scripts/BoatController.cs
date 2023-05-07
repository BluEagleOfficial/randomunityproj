using UnityEngine;
using TMPro;

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

    public TMP_Text ammoText;
    public float shootingCooldown = 1;
    private float timer;
    public Cannon[] cannons;

    public bool canMove = true;

    void Start()
    {
        // cameraObject = GetComponentInChildren<Camera>().gameObject; // not using it for this script at the moment
        speed = maxSpeed;
        information.remainingAmmo = information.Ammo;
        ammoText.text = information.remainingAmmo + " Ammo left";
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(timer < shootingCooldown)
            timer += Time.deltaTime;
        Debug.Log(timer.ToString("F1"));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var cannon in cannons)
            {
                if (information.remainingAmmo > 0 && timer >= shootingCooldown)
                {
                    cannon.shoot();
                    timer = 0;
                }
            }

            if(timer >= shootingCooldown)
            {
                information.remainingAmmo -= 1;
                ammoText.text = information.remainingAmmo + " Ammo left";
            }

            if (information.remainingAmmo < 0)
            {
                information.remainingAmmo = 0;
                ammoText.text = information.remainingAmmo + " Ammo left";
            }
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
