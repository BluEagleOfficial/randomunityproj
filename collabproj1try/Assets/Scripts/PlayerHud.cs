using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image cooldown;
    [SerializeField] private TMP_Text ammoCounter;

    [SerializeField] private Health hp;
    [SerializeField] private BoatController bc;

    void Start()
    {
        
    }

    void Update()
    {
        healthBar.value = hp.hp;
        cooldown.fillAmount = cooldown.fillAmount = -bc.cooldownTimer + 1;
        ammoCounter.text = bc.information.remainingAmmo.ToString() + " Ammo left";
    }
}
