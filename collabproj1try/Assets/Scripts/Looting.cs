using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looting : MonoBehaviour
{
    [SerializeField] private Inventory inv;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("item"))
        {
            Debug.Log("picked up");
        //     ItemBase item = other.GetComponent<Item>();
        //     inv.wood.howMany += item.wood.howMany;
        }
    }
}
