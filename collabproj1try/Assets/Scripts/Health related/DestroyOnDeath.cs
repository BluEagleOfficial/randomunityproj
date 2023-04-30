using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField]
    Health h;
    void Update()
    {
        if (Wyperian.IsNullOrDestroyed(h))
        {
            h = GetComponent<Health>();
        }
        if (h.dead)
        {
            Destroy(this.gameObject);
        }
    }
}
