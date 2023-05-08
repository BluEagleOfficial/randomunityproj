using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "stupidshtMission", menuName = "Missions/stupidshtMission")]
public class stupidsh1t : MissionBase
{
    float timer = 0;

    public float winTime = 60;


    public override void StartMission(GameManager gm)
    {
        win = true;
    }
    public override void UpdateMission(GameManager gm)
    {

    }
    public override void EndMission(GameManager gm)
    {
    }
}
