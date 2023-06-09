using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFlag : MonoBehaviour
{
    public bool hasFlag;
    public bool flagCaptured;

    public Transform flagSpawnPosition;
    public Vector3 grabOffset = new Vector3(0, 32, 4.5f);

    private Health hp;

    public GameObject taker;
    void Start()
    {
        flagSpawnPosition = this.transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boat") && !flagCaptured)
        {
            this.gameObject.transform.SetParent(other.transform);
            this.gameObject.transform.localPosition = grabOffset;
            taker = other.gameObject;
            hp = other.GetComponent<Health>();
            hasFlag = true;
        }

        if (other.CompareTag("enemy base"))
        {
            this.gameObject.transform.SetParent(other.gameObject.transform);
            flagCaptured = true;
            hasFlag = false;
        }

        if (other.CompareTag("Player") && !flagCaptured)
        {
            this.gameObject.transform.SetParent(flagSpawnPosition);
            taker = other.gameObject;
            this.gameObject.transform.localPosition = Vector3.zero;
            hasFlag = false;
        }
    }

    void Update()
    {
        if (hp == null)
            return;
        if (hp.dead)
        {
            this.gameObject.transform.SetParent(null);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
        }
    }
}
