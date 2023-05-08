using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navalMine : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == 4)
            return;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
