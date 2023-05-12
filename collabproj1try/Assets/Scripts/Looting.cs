using UnityEngine;

public class Looting : MonoBehaviour
{
    [SerializeField] private Inventory inv;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            randomDataOfEnemy rd = other.GetComponent<randomDataOfEnemy>();

            inv.wood.howMany += rd.wood;
            inv.iron.howMany += rd.iron;
            inv.gold.howMany += rd.gold;
            inv.gunPowder.howMany += rd.gunpowder;
            Destroy(rd.gameObject);
            Debug.Log("took items");

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            randomDataOfEnemy rd = other.gameObject.GetComponent<randomDataOfEnemy>();

            inv.wood.howMany += rd.wood;
            inv.iron.howMany += rd.iron;
            inv.gold.howMany += rd.gold;
            inv.gunPowder.howMany += rd.gunpowder;
            Destroy(rd.gameObject);
            Debug.Log("took items");

        }
    }
}
