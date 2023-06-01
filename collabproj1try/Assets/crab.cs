using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : MonoBehaviour
{
    public Health health;

    public string enemyTag;

    public damageOnCollision[] dams;
    [SerializeField]
    GameObject[] objectsToStopWhenSmoking;

    Transform player;

    [SerializeField]
    Vector3 surfaceLevel = new Vector3(0, 1, 0);
    [SerializeField]
    bool gettingUp = false;

    [SerializeField]
    float speedOfMoving = 5, distanceOfAttack = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(enemyTag).transform;

    }
    float distance = 0;

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < distanceOfAttack)
        {
            StartCoroutine(attack());
        }

        if (gettingUp)
        {
            getUp();
        }
    }

    void getUp()
    {
        surfaceLevel = new Vector3(transform.position.x, surfaceLevel.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, surfaceLevel, Time.deltaTime * 100 * speedOfMoving);
    }



    IEnumerator attack()
    {
        gettingUp = true;
        yield return new WaitForSeconds(2);

    }
}
