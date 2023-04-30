using UnityEngine;

public class raycastShooter : MonoBehaviour
{
    [SerializeField]
    Transform aimer;

    RaycastHit ray;
    [SerializeField]
    LayerMask ly;
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out ray, Mathf.Infinity, ly))
        {
            aimer.position = ray.point;
        }
    }
}
