using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    int damage = 50;
    void FixedUpdate()
    {
        rb.AddRelativeForce(0, 0, speed);
    }
    void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this);
        }
        catch
        {

        }

    }
    void OnTriggerStay(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this);
        }
        catch
        {

        }
    }
}
