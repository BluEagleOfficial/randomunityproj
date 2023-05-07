using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private Image i;
    [SerializeField] private Cannon c;

    void Update()
    {
        // this doesnt work just constatly makes it spasm so i added a fixed max value that doesnt change
        // i.fillAmount = c.timeOfShoot - i.fillAmount; 
        i.fillAmount = -c.timeOfShoot + 1;
    }
}
