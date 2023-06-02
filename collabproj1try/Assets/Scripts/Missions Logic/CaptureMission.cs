using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CaptureMission", menuName = "Missions/CaptureMission")]
public class CaptureMission : MissionBase
{
    public float timeLeft = 900;

    public GameObject enemyFlagSpawn;
    public GameObject friendlyFlagSpawn;

    private EnemyFlag enemyFlag;
    private FriendlyFlag friendlyFlag;

    public int howManyEnemies = 5;
    public int howManyAllies = 4;

    public Vector3 minEnemyRange = new Vector3(-200, 0, -200), maxEnemyRange = new Vector3(200, 0, 0);
    public Vector3 minAllyRange = new Vector3(-200, 0, 200), maxAllyRange = new Vector3(200, 0, 0);
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> allyPrefabs = new List<GameObject>();

    public GameObject[] enemies;


    public override void StartMission(GameManager gm)
    {
        gm.currentMissionTitle = title;
        GameObject ef = Instantiate(enemyFlagSpawn, new Vector3(0,0,minEnemyRange.z), Quaternion.identity);
        GameObject ff = Instantiate(friendlyFlagSpawn, new Vector3(0,0,minAllyRange.z), Quaternion.identity);

        enemyFlag = ef.GetComponentInChildren<EnemyFlag>();
        friendlyFlag = ff.GetComponentInChildren<FriendlyFlag>();

        for (int i = 0; i < howManyEnemies; i++)
        {
            int randomNumber = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minEnemyRange.x, maxEnemyRange.x), Random.Range(minEnemyRange.y, maxEnemyRange.y), Random.Range(minEnemyRange.z, maxEnemyRange.z));
            Instantiate(enemyPrefabs[randomNumber], pos, Quaternion.identity);
        }

        for (int i = 0; i < howManyAllies; i++)
        {
            int randomNumber = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minAllyRange.x, maxAllyRange.x), Random.Range(minAllyRange.y, maxAllyRange.y), Random.Range(minAllyRange.z, maxAllyRange.z));
            Instantiate(allyPrefabs[randomNumber], pos, Quaternion.identity);
        }
    }
    public override void UpdateMission(GameManager gm)
    {
        enemies = GameObject.FindGameObjectsWithTag("boat");

        timer += Time.deltaTime;

        if (enemyFlag.flagCaptured)
        {
            win = true;
            Debug.Log("SHOULD WIN RIGHT NOW");
        }

        if (friendlyFlag.flagCaptured)
        {
            gm.playerHealth.TakeDamage(10000);
            Debug.Log("Should lose");
        }

        if (timer > timeLeft)
        {

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
