using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    int damage = 50;
    public GameObject hitEffects;
    public GameObject waterHitEffects;

    public string ignoreTag = "";
    void FixedUpdate()
    {
        rb.AddRelativeForce(0, 0, speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != ignoreTag)
        {
            try
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);

            }
            catch
            {

            }
            if (other.gameObject.layer == 4)
                Instantiate(waterHitEffects, transform.position, waterHitEffects.transform.rotation);
            else
                Instantiate(hitEffects, transform.position, Quaternion.identity);
            Destroy(this);

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != ignoreTag)
        {
            try
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);

            }
            catch
            {

            }
            if (other.gameObject.layer == 4)
                Instantiate(waterHitEffects, transform.position, waterHitEffects.transform.rotation);
            else
                Instantiate(hitEffects, transform.position, Quaternion.identity);
            Destroy(this);

        }

    }
}
