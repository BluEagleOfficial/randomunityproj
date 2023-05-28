using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health hp;
    [SerializeField] private Slider s;

    void Update()
    {
        s.maxValue = hp.maxhp;
        s.value = hp.hp;
    }
}
