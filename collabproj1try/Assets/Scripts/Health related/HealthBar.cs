using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health hp;
    [SerializeField] private Slider s;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        s.value = hp.hp;
    }
}
