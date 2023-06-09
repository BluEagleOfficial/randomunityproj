using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    int damage = 50;
    [SerializeField]
    float forceApplied = 5;
    public GameObject hitEffects;
    public GameObject waterHitEffects;

    public string ignoreTag = "";

    public LayerMask notBulleLayermask;

    bool done = false;
    void FixedUpdate()
    {
        rb.AddRelativeForce(0, 0, speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if ((notBulleLayermask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            if (other.gameObject.tag != ignoreTag && !done)
            {
                try
                {
                    other.gameObject.GetComponent<Health>().TakeDamage(damage);
                    Vector3 forceForS = transform.forward * forceApplied;
                    other.gameObject.GetComponentInParent<Rigidbody>().AddForce(forceForS, ForceMode.Impulse);

                }
                catch
                {

                }
                if (other.gameObject.layer == 4)
                    Instantiate(waterHitEffects, transform.position, waterHitEffects.transform.rotation);
                else
                    Instantiate(hitEffects, transform.position, Quaternion.identity);
                done = true;
                Destroy(this);

            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if ((notBulleLayermask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            if (other.gameObject.tag != ignoreTag && !done)
            {
                try
                {
                    other.gameObject.GetComponent<Health>().TakeDamage(damage);
                    try
                    {
                        Vector3 forceForS = transform.forward * forceApplied;
                        other.gameObject.GetComponentInParent<Rigidbody>().AddForce(forceForS, ForceMode.Impulse);
                    }
                    catch
                    {

                    }
                }
                catch
                {

                }
                if (other.gameObject.layer == 4)
                    Instantiate(waterHitEffects, transform.position, waterHitEffects.transform.rotation);
                else
                    Instantiate(hitEffects, transform.position, Quaternion.identity);
                done = true;
                Destroy(this);

            }
        }


    }
}
