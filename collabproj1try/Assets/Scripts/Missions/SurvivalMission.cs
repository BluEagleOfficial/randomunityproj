using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SurvivalMission", menuName = "Missions/SurvivalMission")]
public class SurvivalMission : MissionBase
{
    float timer = 0;

    public float winTime = 60;

    public int howManyEnemies = 10;

    public int enemiesBoatLevel = 0;

    public GameObject[] enemies;


    public override void StartMission(GameManager gm)
    {
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
    }
    public override void EndMission(GameManager gm)
    {
    }
    public override void resetData()
    {
        win = false;
        timer = 0;
    }
}
