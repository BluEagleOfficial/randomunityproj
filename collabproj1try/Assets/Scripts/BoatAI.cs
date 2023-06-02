using UnityEngine;

public class BoatAI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed;
    public float forceSpeed = 1;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;
    public Transform enemy;
    public Cannon[] cannons;

    public Transform aimer;

    public string enemyTag = "Player";

    public LayerMask layerMask;
    void Start()
    {
        enemy = Wyperian.FindClosestEnemy(enemyTag, transform).transform;
        speed = maxSpeed;
    }
    float distance = 0;

    [SerializeField]
    float distanceOfFollow = 1000, distanceOfAttack = 100, distanceOfChange = 100, distanceOfStop = 50;





    void FixedUpdate()
    {
        try
        {
            if (Wyperian.IsNullOrDestroyed(enemy))
            {
                enemy = Wyperian.FindClosestEnemy(enemyTag, transform).transform;
            }
            distance = Vector3.Distance(enemy.position, transform.position);
            if (distance < distanceOfFollow && distance > distanceOfStop)
            {
                follow();
            }
            if (distance < distanceOfAttack)
            {
                aimer.position = enemy.position + new Vector3(0, 1, 0);
                attack();
            }
        }
        catch
        {

        }


    }
    void follow()
    {
        Vector3 rot;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanceOfChange, layerMask))
        {
            // Debug.Log("hit");
            rot = Wyperian.lookAtSlowly(transform, enemy.position, maxRotateSpeed * Time.deltaTime * 1).eulerAngles;
            rb.transform.rotation = Quaternion.Euler(0, rot.y, 0);
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddRelativeForce(0, 0, -forceSpeed);
            }

            // Debug.Log("ehm1");
            rb.AddRelativeForce(forceSpeed, 0, 0);
        }
        else
        {
            // Debug.Log("nohit");
            rot = Wyperian.lookAtSlowly(transform, enemy.position, maxRotateSpeed * Time.deltaTime * 100).eulerAngles;
            rb.transform.rotation = Quaternion.Euler(0, rot.y, 0);
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddRelativeForce(0, 0, forceSpeed);
            }
            if (rb.velocity.magnitude < 1)
            {
                // Debug.Log("ehm2");
                rb.AddRelativeForce(forceSpeed * 10, 0, 0);
            }
        }

    }
    void attack()
    {
        foreach (var cannon in cannons)
        {
            cannon.shoot();
        }
    }
}
