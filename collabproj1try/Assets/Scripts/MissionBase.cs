using System;
using UnityEngine;

public abstract class MissionBase : ScriptableObject
{
    public string title;
    public float timer = 0;
    public bool win;
    public abstract void StartMission(GameManager gm);

    public abstract void UpdateMission(GameManager gm);

    public abstract void EndMission(GameManager gm);

    public abstract void resetData();
}