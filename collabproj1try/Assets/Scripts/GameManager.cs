using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public MissionBase mission;

    public Health playerHealth;
    public static GameManager Instance;

    public bool playerWon = false;

    [SerializeField]
    public GameObject[] prefabs;

    [SerializeField]
    public string ListOfMissions = "";

    void Start()
    {
        Instance = this;
        mission.StartMission(this);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();

    }
    void Update()
    {
        mission.UpdateMission(this);
    }
}
