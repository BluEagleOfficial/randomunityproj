using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textFadeOut : MonoBehaviour
{
    public float aliveTime;
    private float timer;

    public TMP_Text text;

    public float minValue;
    public float maxValue;

    public PlayerHud ph;

    void Update()
    {
        if(ph.loot.randomEnemyData != null)
        {
            if(timer < aliveTime)
            {
                timer += Time.deltaTime;

                text.color = Color.Lerp(Color.white, Color.clear, timer);
                text.gameObject.transform.position = new Vector3(0,Mathf.MoveTowards(minValue, maxValue, timer),0);
            }
            else
            {
                text.color = Color.white;
                text.gameObject.transform.position = new Vector3(0, minValue, 0);
                // text.enabled = false;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
