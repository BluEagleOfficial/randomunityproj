using UnityEngine;

public class destroyafter : MonoBehaviour
{
    [SerializeField]
    float destroyaftersecond = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyaftersecond);
    }

    // Update is called once per frame

}
