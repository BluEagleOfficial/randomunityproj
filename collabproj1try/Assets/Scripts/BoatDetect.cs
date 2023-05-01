using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class BoatDetect : MonoBehaviour
{
    private GameObject detectedObj;
    [SerializeField] private MenuManager mm;
    [SerializeField] private KeyCode interactionButton;
    [SerializeField] private GameObject buttonPrompt;
    [SerializeField] private GameObject eventObj;
    [SerializeField] private GameObject title;
    // public event onBoatSelect;
    
    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            detectedObj = col.gameObject;
            // Debug.Log("boat entered: " + detectedObj);
            buttonPrompt.SetActive(true);
            title.SetActive(true);
            eventObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            detectedObj = null;
            // Debug.Log("boat exited: " + detectedObj);
            buttonPrompt.SetActive(false);
            title.SetActive(false);
            eventObj.SetActive(false);
        }
    }
}
