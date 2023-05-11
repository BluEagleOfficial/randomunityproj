using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "list of missions", menuName = "Missions/list of mission")]
public class ListOfMission : MissionBase
{
    [SerializeField]
    public MissionBase[] missions;

    bool realWin = false;


    public override void StartMission(GameManager gm)
    {

    }
    int currentmission = 0;
    public override void UpdateMission(GameManager gm)
    {
        if (currentmission > missions.Length)
        {
            currentmission = missions.Length;
            gm.playerWon = true;
            realWin = true;
        }
        try
        {
            if (missions[currentmission].win && !realWin)
            {
                currentmission += 1;
            }
        }
        catch
        {
            if (currentmission > missions.Length)
            {
                gm.playerWon = true;
                realWin = true;
            }

        }


        gm.ListOfMissions = "";
        foreach (var mis in missions)
        {
            gm.ListOfMissions += mis.title;
            gm.ListOfMissions += Environment.NewLine;
        }

    }
    public override void EndMission(GameManager gm)
    {
    }
}
