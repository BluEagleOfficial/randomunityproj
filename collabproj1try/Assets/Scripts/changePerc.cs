using UnityEngine;

public class changePerc : MonoBehaviour
{
    [SerializeField]
    Transform cam;

    [SerializeField]
    Vector3 firstPerson = new Vector3(0, 0, 0), thirdPerson = new Vector3(0, 5, -15);


    bool perc = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            perc = !perc;
        }

        if (perc)
        {
            cam.localPosition = firstPerson;
        }
        else
        {
            cam.localPosition = thirdPerson;
        }
    }
}
