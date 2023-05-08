using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageAmmount;

    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player") || other.CompareTag("enemy"))
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
}
