using UnityEngine;

public class Looting : MonoBehaviour
{
    [SerializeField] private Inventory inv;
    public randomDataOfEnemy randomEnemyData;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            randomEnemyData = other.GetComponent<randomDataOfEnemy>();

            inv.wood.howMany += randomEnemyData.wood;
            inv.iron.howMany += randomEnemyData.iron;
            inv.gold.howMany += randomEnemyData.gold;
            inv.gunPowder.howMany += randomEnemyData.gunpowder;
            Destroy(randomEnemyData.gameObject);
            Debug.Log("took items: " + randomEnemyData.wood + " wood, " + randomEnemyData.iron + " iron, " + randomEnemyData.gold + " gold, " + randomEnemyData.gunpowder + " gunpowder, ");

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            randomEnemyData = other.gameObject.GetComponent<randomDataOfEnemy>();

            inv.wood.howMany += randomEnemyData.wood;
            inv.iron.howMany += randomEnemyData.iron;
            inv.gold.howMany += randomEnemyData.gold;
            inv.gunPowder.howMany += randomEnemyData.gunpowder;
            Destroy(randomEnemyData.gameObject);
            Debug.Log("took items: " + randomEnemyData.wood + " wood, " + randomEnemyData.iron + " iron, " + randomEnemyData.gold + " gold, " + randomEnemyData.gunpowder + " gunpowder, ");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
        {
            // randomEnemyData = null;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            // randomEnemyData = null;
        }
    }
}
