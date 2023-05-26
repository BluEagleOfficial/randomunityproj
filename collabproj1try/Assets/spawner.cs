using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] boats;

    public static spawner instance;

    public Vector3 minRange, maxRange;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        instance = this;
    }
    public GameObject[] spawnBoatsWithReturn(int howMany, int indexOfBoat)
    {
        GameObject[] listOfBoats = new GameObject[howMany];
        for (int i = 0; i < howMany; i++)
        {
            Vector3 pos = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
            listOfBoats[i] = Instantiate(boats[indexOfBoat], pos, Quaternion.identity);
        }
        return listOfBoats;
    }
    public void spawnBoats(int howMany, int indexOfBoat)
    {
        for (int i = 0; i < howMany; i++)
        {
            Vector3 pos = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
            Instantiate(boats[indexOfBoat], pos, Quaternion.identity);
        }
    }
    public void spawnBoats(int howMany, float chance1, float chance2, float chance3)
    {
        for (int i = 0; i < howMany; i++)
        {
            float random = Random.Range(0, chance1 + chance2 + chance3);
            Vector3 pos = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
            if (random < chance1)
            {
                Instantiate(boats[0], pos, Quaternion.identity);
            }
            else if (random > chance1 && random < chance2)
            {
                Instantiate(boats[1], pos, Quaternion.identity);
            }
            else if (random > chance2 && random < chance3)
            {
                Instantiate(boats[2], pos, Quaternion.identity);
            }
        }
    }
}
