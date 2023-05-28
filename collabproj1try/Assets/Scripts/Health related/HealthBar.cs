using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health hp;
    [SerializeField] private Slider s;
    [SerializeField] private TMP_Text t;

    void Update()
    {
        s.maxValue = hp.maxhp;
        s.value = hp.hp;
        t.text = hp.hp.ToString() + " Hp";
    }
}
