using UnityEngine;

public class damageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageAmmount;

    void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageAmmount);
        }
        catch
        {

        }

    }
}
