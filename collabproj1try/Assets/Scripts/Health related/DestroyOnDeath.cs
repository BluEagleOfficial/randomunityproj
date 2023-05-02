using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField] Health h;
    [SerializeField] private float timeToDestroy = 20;
    [SerializeField] private float forceOfDown = 100;
    private float timer;

    void Update()
    {
        if (Wyperian.IsNullOrDestroyed(h))
        {
            h = GetComponent<Health>();
        }
        if (h.dead)
        {
            timer += Time.deltaTime;

            if (timer < timeToDestroy)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddRelativeForce(new Vector3(Random.Range(-1, 1), -forceOfDown * Time.deltaTime, 0));
                // add some destroy or explosion particles here
            }
            else
                Destroy(this.gameObject);
        }
    }
}
