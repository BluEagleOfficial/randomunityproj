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
    public int howManyAllies = 0;

    public Vector3 minEnemyRange = new Vector3(-200, 0, -200), maxEnemyRange = new Vector3(200, 0, 0);
    public Vector3 minAllyRange = new Vector3(-200, 0, 200), maxAllyRange = new Vector3(200, 0, 0);
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> allyPrefabs = new List<GameObject>();

    // public GameObject[] enemies;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> allies = new List<GameObject>();
    public List<Health> hps = new List<Health>();
    public bool goingForFlag = true;
    private Health hp;
    private BoatAI ai;
    private GameObject ef;
    private GameObject af;

    public override void StartMission(GameManager gm)
    {
        gm.currentMissionTitle = title;
        enemies.Clear();

        // spawning and getting flag data
        ef = Instantiate(enemyFlagSpawn, new Vector3(0, 0, minEnemyRange.z), Quaternion.identity);
        af = Instantiate(friendlyFlagSpawn, new Vector3(0, 0, minAllyRange.z), Quaternion.identity);
        enemyFlag = ef.GetComponentInChildren<EnemyFlag>();
        friendlyFlag = af.GetComponentInChildren<FriendlyFlag>();

        // spawning enemies and allies
        for (int i = 0; i < howManyEnemies; i++)
        {
            int randomNumberEn = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minEnemyRange.x, maxEnemyRange.x), Random.Range(minEnemyRange.y, maxEnemyRange.y), Random.Range(minEnemyRange.z, maxEnemyRange.z));
            GameObject en = Instantiate(enemyPrefabs[randomNumberEn], pos, Quaternion.identity);
            enemies.Add(en);
        }
        for (int i = 0; i < howManyAllies; i++)
        {
            int randomNumberAl = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minAllyRange.x, maxAllyRange.x), Random.Range(minAllyRange.y, maxAllyRange.y), Random.Range(minAllyRange.z, maxAllyRange.z));
            GameObject al = Instantiate(allyPrefabs[randomNumberAl], pos, Quaternion.identity);
            allies.Add(al);
        }

        // getting the enemies
        // foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(BoatAI)))
        // {
        //     enemies.Add(obj);
        // }
        for (int i = 0; i < enemies.Count; i++)
        {
            hps.Add(enemies[i].GetComponentInChildren<Health>());
        }
    }
    public override void UpdateMission(GameManager gm)
    {
        if (enemyFlag.flagCaptured)
        {
            win = true;
            EndMission(GameManager.Instance);
            Debug.Log("SHOULD WIN RIGHT NOW");
        }

        if (friendlyFlag.flagCaptured)
        {
            gm.playerHealth.hp = 0;
            Debug.Log("Should lose");
        }

        // enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(enemies.Count < howManyEnemies)
        {
            int randomNumber = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minEnemyRange.x, maxEnemyRange.x), Random.Range(minEnemyRange.y, maxEnemyRange.y), Random.Range(minEnemyRange.z, maxEnemyRange.z));
            GameObject obj = Instantiate(enemyPrefabs[randomNumber], pos, Quaternion.identity);
            enemies.Add(obj);
            goingForFlag = false;
        }
        if(allies.Count < howManyAllies)
        {
            int randomNumber = Random.Range(0, 2);
            Vector3 pos = new Vector3(Random.Range(minAllyRange.x, maxAllyRange.x), Random.Range(minAllyRange.y, maxAllyRange.y), Random.Range(minAllyRange.z, maxAllyRange.z));
            GameObject obj = Instantiate(allyPrefabs[randomNumber], pos, Quaternion.identity);
            allies.Add(obj);
        }

        for (int i = 0; i < hps.Count; i++)
        {
            if (hps[i].dead)
            {
                enemies.RemoveAt(i);
                hps.RemoveAt(i);
            }
        }

        if (goingForFlag == false)
        {
            if (ai != null)
                return;
            ai = enemies[0].GetComponent<BoatAI>();
            // hp = enemies[0].GetComponentInChildren<Health>();
            hp = hps[0];

            Debug.Log("boat ai is: " + ai);
            // Debug.Log("boat hp is: " + hp);

            ai.enemy = friendlyFlag.transform;
            ai.enemyTag = "friendly flag";
            Debug.Log("attack fucking: " + ai.enemyTag);
            goingForFlag = true;
        }
        if (hp != null && hp.dead)
        {
            goingForFlag = false;
        }

        if (friendlyFlag.hasFlag)
        {
            ai.enemyTag = "enemy base";
        }

        timer += Time.deltaTime;


        if (timer > timeLeft)
        {

        }
    }
    public override void EndMission(GameManager gm)
    {
        Destroy(ef);
        Destroy(af);
    }
    public override void resetData()
    {
        // ai = null;
        // hp = null;
        // enemies = null;
        // goingForFlag = false;
        win = false;
        timer = 0;
    }
}
