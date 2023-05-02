using UnityEngine;

public class waterPhysics : MonoBehaviour
{
    public float waterStrength = 5;
    void OnTriggerStay(Collider other)
    {
        try
        {
            //dont add 2 GetComponent in a loop , it slows down the CPU, even this one i added is considered bad
            //but what do i :(( i need water to push
            other.GetComponentInParent<Rigidbody>().AddForce(0, waterStrength * Time.deltaTime, 0, ForceMode.Impulse);
        }
        catch
        {

        }
    }
}
