using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health hp;
    [SerializeField] private Slider s;
    [SerializeField] private TMP_Text t;

    bool cantText = false;
    void Update()
    {
        s.maxValue = hp.maxhp;
        s.value = hp.hp;
        if (!cantText)
        {
            try
            {
                t.text = hp.hp.ToString() + " Hp";
            }
            catch
            {
                cantText = true;
            }
        }


    }
}
