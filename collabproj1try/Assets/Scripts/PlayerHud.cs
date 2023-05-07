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

    [SerializeField] private BoatController bc;
    [SerializeField] private Health hp;

    void Update()
    {
        healthBar.value = hp.hp;
        ammoCounter.text = bc.information.remainingAmmo.ToString() + " Ammo left";
        if(bc.information.remainingAmmo > 0)
            cooldown.fillAmount = cooldown.fillAmount = -bc.cooldownTimer + 1;
    }
}
