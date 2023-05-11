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
    public List<TMP_Text> missionTexts = new List<TMP_Text>();

    void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    void Update()
    {
        healthBar.value = hp.hp;
        ammoCounter.text = bc.information.remainingAmmo.ToString() + " Ammo left";
        if(bc.information.remainingAmmo > 0)
            cooldown.fillAmount = cooldown.fillAmount = -bc.cooldownTimer + 1;
        if(MenuManager.gamePaused)
            cooldown.gameObject.SetActive(false);
        else
            cooldown.gameObject.SetActive(true);

        // if(Input.GetKey(KeyCode.K))
        if(GameManager.Instance.playerWon == true)
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
