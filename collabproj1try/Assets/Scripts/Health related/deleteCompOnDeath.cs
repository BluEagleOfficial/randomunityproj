using UnityEngine;

public class deleteCompOnDeath : MonoBehaviour
{
    [SerializeField]
    Health h;

    [SerializeField]
    Component comp;
    void Update()
    {
        if (h.dead)
        {
            Destroy(comp);
        }
    }
}
