using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SurvivalMission", menuName = "Missions/SurvivalMission")]
public class SurvivalMission : MissionBase
{

    public float winTime = 60;

    public int howManyEnemies = 10;

    public int enemiesBoatLevel = 0;

    public GameObject[] enemies;


    public override void StartMission(GameManager gm)
    {
        resetData();
        gm.currentMissionTitle = title;

        spawner.instance.spawnBoats(howManyEnemies, enemiesBoatLevel);
    }
    public override void UpdateMission(GameManager gm)
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        timer += Time.deltaTime;
        if (timer > winTime)
        {
            if (!gm.playerHealth.dead)
            {
                win = true;
            }
        }
        if (enemies.Length < howManyEnemies)
        {
            spawner.instance.spawnBoats(1, enemiesBoatLevel);
        }
        if (win)
        {
            EndMission(gm);
        }
    }
    public override void EndMission(GameManager gm)
    {

        foreach (var item in enemies)
        {
            Destroy(item);
        }
    }
    public override void resetData()
    {
        win = false;
        timer = 0;
    }
}
