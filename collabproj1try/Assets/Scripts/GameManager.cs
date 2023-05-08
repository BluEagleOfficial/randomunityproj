using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public MissionBase mission;

    public Health playerHealth;

    public bool playerWon;
    void Start()
    {
        mission.StartMission(this);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();

    }
    void Update()
    {
        mission.UpdateMission(this);
        playerWon = mission.win;
    }
}
