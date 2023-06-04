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
    bool attacking = false;
    [SerializeField]
    float speedOfMoving = 5, distanceOfAttack = 10, speedOfRot = 5;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(enemyTag).transform;

    }
    float distance = 0;

    bool alive = true;
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        alive = !health.dead;
        if (distance < distanceOfAttack)
        {
            StartCoroutine(attack());


        }
        else
        {
            follow();

        }
        if (gettingUp)
        {
            getUp();
        }
        if (attacking)
        {
            startAttack();
        }
        else
        {
            stopAttack();
        }
    }
    void follow()
    {
        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * speedOfMoving);
    }
    void startAttack()
    {
        if (!dams[0].enabled)
        {
            foreach (damageOnCollision dam in dams)
            {
                dam.enabled = true;
            }
        }
    }
    void stopAttack()
    {
        if (dams[0].enabled)
        {
            foreach (damageOnCollision dam in dams)
            {
                dam.enabled = false;
            }
        }
    }
    void getUp()
    {
        surfaceLevel = new Vector3(transform.position.x, surfaceLevel.y, transform.position.z);
        transform.rotation = Wyperian.lookAtSlowly(transform, player.position, speedOfRot * Time.deltaTime * 100);
        transform.position = Vector3.MoveTowards(transform.position, surfaceLevel, Time.deltaTime * 100 * speedOfMoving);
    }

    IEnumerator attack()
    {

        gettingUp = true;
        yield return new WaitForSeconds(2);
        attacking = true;
        Debug.Log("here1");
        yield return 0;

    }
}
