using System;
using UnityEngine;

[CreateAssetMenu(fileName = "list of missions", menuName = "Missions/list of mission")]
public class ListOfMission : MissionBase
{
    [SerializeField]
    public MissionBase[] missions;
    [SerializeField]
    bool realWin = false;

    int currentmission = 0;
    public override void StartMission(GameManager gm)
    {
        resetData();
        missions[currentmission].StartMission(gm);
        currentmission = 0;
        Debug.Log(currentmission);
    }


    int howManyWins = 0;
    public override void UpdateMission(GameManager gm)
    {
        if (!realWin)
        {
            howManyWins = 0;
            gm.ListOfMissions = "";
            if (currentmission >= missions.Length)
            {
                win = true;
                realWin = true;
                gm.playerWon = true;
                currentmission = missions.Length - 1;
            }
            if (missions[currentmission].win)
            {
                if (currentmission < missions.Length - 1)
                {
                    currentmission += 1;
                    missions[currentmission].StartMission(gm);
                }
            }
            for (int i = 0; i < missions.Length; i++)
            {
                gm.ListOfMissions += missions[i].title;
                gm.ListOfMissions += Environment.NewLine;
                if (missions[i].win)
                {
                    howManyWins += 1;
                }
            }
            if (howManyWins >= missions.Length)
            {
                gm.playerWon = true;
                win = true;
                realWin = true;
            }
            missions[currentmission].UpdateMission(gm);
            Debug.Log(currentmission);
        }


    }
    public override void EndMission(GameManager gm)
    {

        missions[currentmission].EndMission(gm);
        resetData();
    }
    public override void resetData()
    {
        currentmission = 0;
        howManyWins = 0;

        win = false;
        realWin = false;
        GameManager.Instance.playerWon = false;
        foreach (var item in missions)
        {
            item.resetData();
        }
    }
}
