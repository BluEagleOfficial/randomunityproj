using UnityEngine;

public class lockRotation : MonoBehaviour
{
    Quaternion q;
    void Start()
    {
        q = transform.rotation;
    }
    void Update()
    {
        transform.rotation = q;
    }
}
