using UnityEngine;

public class randomSpawnGameobjects : MonoBehaviour
{
    [SerializeField]
    GameObject spawn;

    [SerializeField]
    Vector3 min, max;

    [SerializeField]
    int howMany = 10;

    void Start()
    {
        for (int i = 0; i < howMany; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
            );
            Instantiate(spawn, randomPos, Quaternion.identity);
        }
    }
}
