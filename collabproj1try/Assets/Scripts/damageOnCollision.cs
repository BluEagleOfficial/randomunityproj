using UnityEngine;

public class damageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageAmmount;

    [SerializeField] private float forceStrength = 100;
    [SerializeField] private float distance = 250;

    void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageAmmount);
            other.gameObject.GetComponentInParent<Rigidbody>().AddExplosionForce(forceStrength, transform.position, distance, 1, ForceMode.Impulse);
        }
        catch
        {

        }

    }
}
