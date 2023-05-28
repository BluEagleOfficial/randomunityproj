using System;
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

    void Awake()
    {
        Instance = this;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();

        mission.resetData();


        mission.StartMission(this);
    }


    void Update()
    {
        mission.UpdateMission(this);
        if (playerHealth.dead)
        {
            mission.EndMission(this);
        }

    }

    void OnApplicationQuit()
    {
        mission.resetData();
        mission.EndMission(this);
    }


}
