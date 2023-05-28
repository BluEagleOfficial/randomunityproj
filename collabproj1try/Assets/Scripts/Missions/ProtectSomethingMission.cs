using UnityEngine;
[CreateAssetMenu(fileName = "Protect Something", menuName = "Missions/Protect Something")]
public class ProtectSomethingMission : MissionBase
{
    public GameObject prefabOfEnemies;

    public GameObject[] enemies;

    public string tagOfEnemies = "enemy";

    public string tagOfProtect = "protect";

    [SerializeField]
    GameObject protect;

    Health protectHealth;
    GameObject g;
    public float howManySeconds = 120;
    public int howManyEnemies = 10;

    public int enemiesBoatLevel = 0;
    public override void StartMission(GameManager gm)
    {
        timer = 0;
        win = false;
        g = Instantiate(prefabOfEnemies, Vector3.zero, Quaternion.identity);
        protect = GameObject.FindGameObjectWithTag(tagOfProtect);
        protectHealth = protect.GetComponent<Health>();
    }

    public override void UpdateMission(GameManager gm)
    {
        if (protect == null)
        {
            g = Instantiate(prefabOfEnemies, Vector3.zero, Quaternion.identity);
            protect = GameObject.FindGameObjectWithTag(tagOfProtect);
            protectHealth = protect.GetComponent<Health>();
        }
        enemies = GameObject.FindGameObjectsWithTag(tagOfEnemies);
        timer += Time.deltaTime;
        if (enemies.Length < howManyEnemies && !Wyperian.IsNullOrDestroyed(protect.tag) && !gm.playerHealth.dead)
        {
            GameObject[] en = spawner.instance.spawnBoatsWithReturn(1, enemiesBoatLevel);
            foreach (GameObject gg in en)
            {
                BoatAI a = gg.GetComponent<BoatAI>();
                a.enemyTag = protect.tag;
            }
        }
        if (timer > howManySeconds)
        {
            win = true;
            Done();
        }
        if (protectHealth.dead)
        {
            gm.playerHealth.hp = -100;
            win = false;
        }

    }
    public override void EndMission(GameManager gm)
    {
        Done();
        resetData();
    }

    void Done()
    {
        Destroy(protect);
        foreach (var ga in enemies)
        {
            Destroy(ga);
        }
        Destroy(g);

    }
    public override void resetData()
    {

        timer = 0;
        win = false;

    }

}
