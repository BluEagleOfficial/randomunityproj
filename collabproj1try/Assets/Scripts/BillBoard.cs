using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        try
        {
            if (Wyperian.IsNullOrDestroyed(cam))
            {
                cam = Camera.current;
            }
            transform.LookAt(cam.transform.position);
        }
        catch
        {

        }

    }
}
