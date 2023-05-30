using System;
using UnityEngine;


[CreateAssetMenu(fileName = "stupidshtMission", menuName = "Missions/stupidshtMission")]
public class stupidsh1t : MissionBase
{
    // float timer = 0;


    public override void StartMission(GameManager gm)
    {
        win = true; gm.currentMissionTitle = title;

    }
    public override void UpdateMission(GameManager gm)
    {
        win = true;
    }
    public override void EndMission(GameManager gm)
    {

    }
    public override void resetData()
    {
        win = false;
        // timer = 0;
    }
}
