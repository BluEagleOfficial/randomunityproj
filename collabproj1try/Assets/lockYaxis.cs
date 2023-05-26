using UnityEngine;

public class lockYaxis : MonoBehaviour
{
    public Vector3 pos = new Vector3(0, 0.4450006f, 0);
    void Start()
    {

    }
    void Update()
    {
        Vector3 p = new Vector3(transform.position.x, pos.y, transform.position.z);
        transform.position = p;
    }
}
