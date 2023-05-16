using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public static bool lockCamera;

    private float axisX,axisY;
    private float rotX,rotY;
    public bool clampCamera = true;
    public float minLimit = -90f;
    public float maxLimit = 90f;
    public float sensitivity = 100;

    void Start()
    {
        
    }


    void Update()
    {
        axisX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensitivity;
        axisY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensitivity;
        rotX -= axisY;
        rotY += axisX;
    }

    void FixedUpdate()
    {
        if(lockCamera)
            return;
        if(clampCamera == true)
            rotX = Mathf.Clamp(rotX, minLimit, maxLimit);

        this.gameObject.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }
}
