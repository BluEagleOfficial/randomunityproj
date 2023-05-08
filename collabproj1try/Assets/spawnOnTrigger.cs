using UnityEngine;

public class spawnOnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject spawn;

    [SerializeField]
    bool destroyOnTouch = false;
    void OnTriggerEnter(Collider other)
    {
        try
        {
            Health hp = other.GetComponent<Health>();

            if (!Wyperian.IsNullOrDestroyed(hp))
            {
                Instantiate(spawn, transform.position, Quaternion.identity);
                if (destroyOnTouch)
                    Destroy(gameObject);
            }
        }
        catch
        {

        }
    }
}
