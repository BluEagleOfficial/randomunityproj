using UnityEngine;

public class randomDataOfEnemy : MonoBehaviour
{
    public int wood = 0, iron = 0, gold = 0, gunpowder = 0;

    public Vector2 range = new Vector2(0, 100);

    void Awake()
    {
        wood = (int)Random.Range(range.x, range.y);
        iron = (int)Random.Range(range.x, range.y);
        gold = (int)Random.Range(range.x, range.y);
        gunpowder = (int)Random.Range(range.x, range.y);
    }
}
