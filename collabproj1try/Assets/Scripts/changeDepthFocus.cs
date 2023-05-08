using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class changeDepthFocus : MonoBehaviour
{
    [SerializeField] Volume v;

    DepthOfField dof;

    [SerializeField]
    Transform cam;
    [SerializeField]
    LayerMask ly;
    [SerializeField]
    float speed = 100;
    void Start()
    {
        v.profile.TryGet<DepthOfField>(out dof);

    }

    RaycastHit r;
    void Update()
    {
        if (Physics.Raycast(cam.position, cam.forward, out r, 1000, ly))
        {
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, r.distance, Time.deltaTime * speed);
        }
        else
        {
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, 10, Time.deltaTime * speed);
        }

    }
}
