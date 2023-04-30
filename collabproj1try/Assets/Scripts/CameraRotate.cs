using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float axisX,axisY;
    private float rotX,rotY;
    public bool clampCamera = true;
    public float minLimit = -90f;
    public float maxLimit = 90f;
    public float sensitivity = 100;

    private bool lockCursor = true;

    void Start()
    {
        
    }


    void Update()
    {
        axisX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensitivity;
        axisY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensitivity;
        rotX -= axisY;
        rotY += axisX;

        LockCursor(lockCursor);
        if(Input.GetKeyDown(KeyCode.L))
            lockCursor = !lockCursor;
    }

    void FixedUpdate()
    {
        if(clampCamera == true)
            rotX = Mathf.Clamp(rotX, minLimit, maxLimit);

        this.gameObject.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    void LockCursor(bool LockCursor) // moved to cameracontroller script
    {
        if(LockCursor == true)
            Cursor.lockState = CursorLockMode.Locked;
        if(LockCursor == false)
            Cursor.lockState = CursorLockMode.None;
    }
}
