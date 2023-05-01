using UnityEngine;

public class BoatAI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed;
    public float forceSpeed = 1;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;
    public Transform enemy;
    public Cannon canon;

    public Transform aimer;
    void Start()
    {
        enemy = Wyperian.FindClosestEnemy("boat", transform).transform;
        speed = maxSpeed;
    }
    float distance = 0;

    [SerializeField]
    float distanceOfFollow = 1000, distanceOfAttack = 100;


    void FixedUpdate()
    {
        if (Wyperian.IsNullOrDestroyed(enemy))
        {
            enemy = Wyperian.FindClosestEnemy("boat", transform).transform;
        }
        distance = Vector3.Distance(enemy.position, transform.position);
        if (distance < distanceOfFollow && distance > distanceOfAttack)
        {
            follow();
        }
        if (distance < distanceOfAttack)
        {
            aimer.position = enemy.position + new Vector3(0, 1, 0);
            attack();
        }

    }
    void follow()
    {
        Vector3 rot = Wyperian.lookAtSlowly(transform, enemy.position, maxRotateSpeed * Time.deltaTime * 100).eulerAngles;
        rb.transform.rotation = Quaternion.Euler(0, rot.y, 0);
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(0, 0, forceSpeed);
        }
    }
    void attack()
    {
        canon.shoot();
    }
}