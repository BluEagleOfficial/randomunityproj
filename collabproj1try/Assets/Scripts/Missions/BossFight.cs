using System;
using UnityEngine;


[CreateAssetMenu(fileName = "bossMission", menuName = "Missions/bossMission")]
public class BossFight : MissionBase
{
    float timer = 0;
    [SerializeField] private GameObject BossPrefab;
    private GameObject boss;

    public override void StartMission(GameManager gm)
    {
        boss = Instantiate(BossPrefab, Vector3.zero, Quaternion.identity);
    }
    public override void UpdateMission(GameManager gm)
    {
        if(boss == null)
            win = true;
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
