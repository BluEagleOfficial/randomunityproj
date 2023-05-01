using UnityEngine;

public class waterPhysics : MonoBehaviour
{
    public float waterStrength = 5;
    void OnTriggerStay(Collider other)
    {
        try
        {
            if(other.GetComponentInParent<Health>().dead == false)
                other.GetComponentInParent<Rigidbody>().AddForce(0, waterStrength * Time.deltaTime, 0, ForceMode.Impulse);
        }
        catch
        {

        }
    }
}
