using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "SurvivalMission", menuName = "Missions/SurvivalMission")]
public class SurvivalMission : MissionBase
{
    float timer = 0;

    public float winTime = 60;


    public override void StartMission(GameManager gm)
    {

    }
    public override void UpdateMission(GameManager gm)
    {
        timer += Time.deltaTime;
        if (timer > winTime)
        {
            if (!gm.playerHealth.dead)
            {
                win = true;
            }

        }
    }
    public override void EndMission(GameManager gm)
    {
    }
}
