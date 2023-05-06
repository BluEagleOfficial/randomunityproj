using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 1;
    private float timer;

    void Update()
    {
        if(timer < timeToDestroy)
            timer += Time.deltaTime;
        else
            Destroy(this.gameObject);
    }
}
