using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField] Health h;
    [SerializeField] BoatController bc;
    [SerializeField] private float timeToDestroy = 20;
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

            if(timer < timeToDestroy)
            {
                if(bc != null)
                    bc.canMove = false;
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddRelativeForce(new Vector3(Random.Range(-1,1),1,0));
                // add some destroy or explosion particles here
            }
            else
                Destroy(this.gameObject);
        }
    }
}
