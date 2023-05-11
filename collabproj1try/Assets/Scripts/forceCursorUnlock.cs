using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceCursorUnlock : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
