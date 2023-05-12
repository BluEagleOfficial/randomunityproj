using UnityEngine;

public class spawnOnDeath : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawns;

    [SerializeField]
    Health hp;

    bool done = false;
    void Update()
    {
        if (hp.dead && !done)
        {
            foreach (var item in spawns)
            {
                Instantiate(item, transform.position + Vector3.up, Quaternion.identity);
            }
            done = true;
        }
    }
}
