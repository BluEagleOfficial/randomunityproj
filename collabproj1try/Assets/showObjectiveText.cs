using UnityEngine;
using TMPro;

public class showObjectiveText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TMP_Text txt;

    GameManager gm;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = GameManager.Instance;
    }
    void Update()
    {
        txt.text = "Objective: \n " +
        gm.currentMissionTitle;
    }
}
