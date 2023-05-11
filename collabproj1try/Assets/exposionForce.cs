using UnityEngine;

public class exposionForce : MonoBehaviour
{
    [SerializeField]
    float forceS = 10;
    [SerializeField]
    float distanceOfAttack = 1000;
    void Start()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        // Iterate through each rigidbody
        foreach (Rigidbody rb in rigidbodies)
        {
            // Calculate the distance between the explosion point and the rigidbody
            float distance = Vector3.Distance(transform.position, rb.transform.position);

            // Check if the rigidbody is close enough to the explosion point
            if (distance <= distanceOfAttack)
            {
                // Calculate the explosion force vector
                Vector3 explosionForceVector = (rb.transform.position - transform.position).normalized * forceS;

                // Apply the explosion force to the rigidbody
                rb.AddForce(explosionForceVector, ForceMode.Impulse);
            }
        }
    }
}
