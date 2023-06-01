using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFlag : MonoBehaviour
{
    public bool hasFlag;
    public bool flagCaptured;

    public Transform flagSpawnPosition;
    public Vector3 grabOffset = new Vector3(0,32,4.5f);

    void Start()
    {
        flagSpawnPosition = this.transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("boat"))
        {
            this.gameObject.transform.SetParent(other.transform);
            this.gameObject.transform.position = grabOffset;
            hasFlag = true;
        }

        if(other.CompareTag("enemy base"))
        {
            this.gameObject.transform.SetParent(other.gameObject.transform);
            flagCaptured = true;
            hasFlag = false;
        }

        if(other.CompareTag("Player"))
        {
            this.gameObject.transform.SetParent(flagSpawnPosition);
            this.gameObject.transform.position = Vector3.zero;
            hasFlag = false;
        }
    }
}
