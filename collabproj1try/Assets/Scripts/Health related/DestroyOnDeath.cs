using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField] Health h;
    [SerializeField] private float timeToDestroy = 20;
    [SerializeField] private float forceOfDown = 100;
    [SerializeField] private GameObject DeathEffectsPrefab;
    private float timer;
    private GameObject prefab;

    void Update()
    {
        if (Wyperian.IsNullOrDestroyed(h))
        {
            h = GetComponent<Health>();
        }
        try
        {
            if(GameManager.Instance.playerWon)
                return;
            if (h.dead)
            {
                timer += Time.deltaTime;

                if (timer < timeToDestroy)
                {
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.constraints = RigidbodyConstraints.None;
                    rb.AddRelativeForce(new Vector3(Random.Range(-1, 1), -forceOfDown * Time.deltaTime, 0));
                    if (prefab == null)
                        prefab = Instantiate(DeathEffectsPrefab, transform.position, Quaternion.identity);
                }
                else
                    Destroy(this.gameObject);
            }
        }
        catch
        {

        }


    }
}
