using UnityEngine;

public class waterPhysics : MonoBehaviour
{
    public float waterStrength = 5;
    void OnTriggerStay(Collider other)
    {
        try
        {
            other.GetComponentInParent<Rigidbody>().AddForce(0, waterStrength * Time.deltaTime, 0, ForceMode.Impulse);
        }
        catch
        {

        }
    }
}
