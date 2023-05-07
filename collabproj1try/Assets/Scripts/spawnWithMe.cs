using UnityEngine;

public class spawnWithMe : MonoBehaviour
{
    [SerializeField]
    GameObject g;
    void Awake()
    {
        Instantiate(g, transform.position, Quaternion.identity);
    }
}
