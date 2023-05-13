using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHud : MonoBehaviour
{
    public static PlayerHud Instance;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image cooldown;
    [SerializeField] private TMP_Text ammoCounter;
    [SerializeField] private GameObject winScreen;
    // [SerializeField] private float animationSmoothness = 5;

    [SerializeField] private BoatController bc;
    [SerializeField] private Health hp;
    [SerializeField] private Inventory inv;
    public Looting loot;
    public TMP_Text missionTexts;

    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text ironText;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text gunpowderText;

    [SerializeField] private TMP_Text woodNotif;
    [SerializeField] private TMP_Text ironNotif;
    [SerializeField] private TMP_Text goldNotif;
    [SerializeField] private TMP_Text gunpowderNotif;

    // private randomDataOfEnemy prevData;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        
        // Reset items on start since scriptable objects save the ammount even after exiting play mode
        inv.wood.howMany = 0;
        inv.iron.howMany = 0;
        inv.gold.howMany = 0;
        inv.gunPowder.howMany = 0;
    }

    void Update()
    {
        healthBar.value = hp.hp;
        ammoCounter.text = bc.information.remainingAmmo.ToString() + " Ammo left";
        if (bc.information.remainingAmmo > 0)
            cooldown.fillAmount = cooldown.fillAmount = -bc.cooldownTimer + 1;

        // if pause menu is active hide the crosshair and cooldown so it doesnt appear on top
        if (MenuManager.gamePaused)
            cooldown.gameObject.SetActive(false);
        else
            cooldown.gameObject.SetActive(true);

        missionTexts.text = GameManager.Instance.ListOfMissions;

        woodText.text = inv.wood.howMany.ToString();
        ironText.text = inv.iron.howMany.ToString();
        goldText.text = inv.gold.howMany.ToString();
        gunpowderText.text = inv.gunPowder.howMany.ToString();

        // if(loot.randomEnemyData != null) // i tried making some really cool "+30" text that fades out and goes up
        // {
        //     // if(loot.randomEnemyData == prevData)
        //     //     return;
        //     // else
        //     //     prevData = loot.randomEnemyData;
            
        //     if(loot.randomEnemyData.wood != 0)
        //     {
        //         // woodNotif.enabled = true;
        //         woodNotif.text = loot.randomEnemyData.wood.ToString();
        //     }
        //     if(loot.randomEnemyData.iron != 0)
        //     {
        //         // ironNotif.enabled = true;
        //         ironNotif.text = loot.randomEnemyData.iron.ToString();
        //     }
        //     if(loot.randomEnemyData.gold != 0)
        //     {
        //         // goldNotif.enabled = true;
        //         goldNotif.text = loot.randomEnemyData.gold.ToString();
        //     }
        //     if(loot.randomEnemyData.gunpowder != 0)
        //     {
        //         // gunpowderNotif.enabled = true;
        //         gunpowderNotif.text = loot.randomEnemyData.gunpowder.ToString();
        //     }
        // }

        // if(Input.GetKey(KeyCode.K))
        if (GameManager.Instance.playerWon == true)
        {
            winScreen.SetActive(true);
            // LeanTween.scaleY(winScreen,1,Time.deltaTime); // idk i cant do it, it just gets stuck twitching
            // winScreen.transform.localScale = Vector3.MoveTowards(new Vector3(1,0,1), Vector3.one, animationSmoothness * Time.deltaTime);
        }
        else
        {
            // winScreen.transform.localScale = Vector3.MoveTowards(Vector3.one, new Vector3(1,0,1), animationSmoothness * Time.deltaTime);
            // if(winScreen.transform.localScale == new Vector3(1,0,1))
            winScreen.SetActive(false);
        }
    }
}
