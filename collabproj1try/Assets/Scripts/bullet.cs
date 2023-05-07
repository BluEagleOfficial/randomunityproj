using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    int damage = 50;
    public GameObject replace;

    [SerializeField]
    private AudioClip hitSound;

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
            Instantiate(replace, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySoundAtPosition(hitSound, transform.position, Random.Range(10,100), 100);
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
            Instantiate(replace, transform.position, Quaternion.identity);
            Destroy(this);

        }

    }
}
