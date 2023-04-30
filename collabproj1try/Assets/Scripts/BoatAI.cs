using UnityEngine;

public class BoatAI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed;
    public float forceSpeed = 1;
    public float maxSpeed = 10;
    public float maxRotateSpeed = 1;
    public Transform enemy;
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
            attack();
        }

    }
    void follow()
    {

    }
    void attack()
    {

    }
}
