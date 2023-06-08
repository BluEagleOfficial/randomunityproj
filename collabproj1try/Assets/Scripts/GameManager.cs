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
    public string currentMissionTitle = "";

    void Awake()
    {
        try
        {
            Instance = this;
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();

            mission.resetData();


            mission.StartMission(this);
        }
        catch
        {

        }

    }


    void Update()
    {
        try
        {
            mission.UpdateMission(this);
            if (playerHealth.dead)
            {
                mission.EndMission(this);
            }

        }
        catch
        {

        }

    }

    void OnApplicationQuit()
    {
        mission.resetData();
        mission.EndMission(this);
    }


}
