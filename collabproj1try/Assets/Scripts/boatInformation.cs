using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/boatInformation")]
public class boatInformation : ScriptableObject
{
    public float coins = 0;
    public int ammos = 10;

    public int maxHealth = 1000;

    public int health = 1000;

    public float maxSpeed = 10;

    public float maxRotateSpeed = 1;

    void Update()
    {

    }
}
