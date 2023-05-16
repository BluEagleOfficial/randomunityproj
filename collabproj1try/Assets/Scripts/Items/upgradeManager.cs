using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
    [SerializeField] private BoatController bc;
    [SerializeField] private Health hp;
    [SerializeField] private Inventory inv;
    [SerializeField] private boatInformation info;

    [SerializeField] private Vector4 speedCost, defenceCost, cannonCost, ammoCost;

    [SerializeField] private Slider speedBar, defenceBar, cannonsBar;
    private int speedLevel = 1, defenceLevel = 1, cannonsLevel = 1;
    [SerializeField] private TMP_Text AmmoIronText, AmmoGoldText, AmmoGunpowderText;
    [SerializeField] private TMP_InputField ammoInput;

    public void UpgradeSpeed()
    {
        if (speedLevel > 9)
            return;
        if (hasEnoughItems(speedCost))
        {
            speedLevel += 1;
            speedBar.value = speedLevel;

            bc.maxSpeed += speedLevel;
            bc.maxRotateSpeed += speedLevel / 10; // reduced so the rotate speed is not way too fast
            ConsumeItems(speedCost);
        }
    }

    public void UpgradeDefence()
    {
        if (defenceLevel > 9)
            return;
        if (hasEnoughItems(defenceCost))
        {
            defenceLevel += 1;
            defenceBar.value = defenceLevel;

            hp.maxhp += defenceLevel * 50;
            hp.healHp(defenceLevel * 50);
            ConsumeItems(defenceCost);
        }
    }

    public void UpgradeCannons()
    {
        if (hasEnoughItems(cannonCost))
        {
            if (cannonsLevel > 9)
                return;

            cannonsLevel += 1;
            cannonsBar.value = cannonsLevel;

            for (int i = 0; i < cannonsLevel; i++)
            {
                if (!bc.cannons[i].isActiveAndEnabled)
                    bc.cannons[i].gameObject.SetActive(true);
            }
            ConsumeItems(cannonCost);
        }
    }

    public void AddAmmo()
    {
        if (ammoInput.text == "")
            return;
        if (hasEnoughItems(ammoCost * int.Parse(ammoInput.text)))
        {
            info.remainingAmmo += int.Parse(ammoInput.text);
            ConsumeItems(ammoCost * int.Parse(ammoInput.text));
        }
    }

    public void UpdateAmmoCost()
    {
        if (ammoInput.text != "")
        {
            int multiplier = int.Parse(ammoInput.text);
            AmmoIronText.text = (ammoCost.y * multiplier).ToString();
            AmmoGoldText.text = (ammoCost.z * multiplier).ToString();
            AmmoGunpowderText.text = (ammoCost.w * multiplier).ToString();
        }
        else
        {
            AmmoIronText.text = (ammoCost.y).ToString();
            AmmoGoldText.text = (ammoCost.z).ToString();
            AmmoGunpowderText.text = (ammoCost.w).ToString();
        }
    }

    public void ConsumeItems(Vector4 items)
    {
        inv.wood.howMany -= (int)items.x;
        inv.iron.howMany -= (int)items.y;
        inv.gold.howMany -= (int)items.z;
        inv.gunPowder.howMany -= (int)items.w;
    }

    public bool hasEnoughItems(Vector4 items)
    {
        if (
        inv.wood.howMany <= items.x ||
        inv.iron.howMany <= items.y ||
        inv.gold.howMany <= items.z ||
        inv.gunPowder.howMany <= items.w
        )
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
