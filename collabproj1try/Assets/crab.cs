using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : MonoBehaviour
{
    public Health health;

    public Animator an;
    public string enemyTag;
    [SerializeField]
    ParticleSystem smokeOfCigars;

    [SerializeField]
    ParticleSystem largeSmoke;
    public damageOnCollision[] dams;
    [SerializeField]
    GameObject[] objectsToStopWhenSmoking;

    Transform player;

    [SerializeField]
    Vector3 surfaceLevel = new Vector3(0, 1, 0),
    underSurfaceLevel = new Vector3(0, -100f, 0);
    [SerializeField]
    bool gettingUp = false;
    bool attacking = false;
    [SerializeField]
    float speedOfMoving = 5, distanceOfAttack = 10, speedOfRot = 5;
    [SerializeField]
    float timeToAttack = 5, timeToSmoke = 30;

    float timerOfAttack = 0, timerOfSmoke = 0;

    float normalEmission = 0, largeSmokeEmission = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(enemyTag).transform;
        normalEmission = smokeOfCigars.emissionRate;
        largeSmokeEmission = largeSmoke.emissionRate;
        largeSmoke.emissionRate = 0;
    }
    float distance = 0;
    [SerializeField]
    bool alive = true;
    int lastHealth = 0;
    void Update()
    {
        if (alive)
        {
            if (lastHealth > health.hp)
            {
                timerOfAttack = 0;
                stopAttack();
                gettingUp = false;
                attacking = false;

            }
            Vector3 sss = new Vector3(transform.position.x, 0, transform.position.z);
            distance = Vector3.Distance(sss, player.position);
            timerOfAttack += Time.deltaTime;
            timerOfSmoke += Time.deltaTime;
            alive = !health.dead;
            if (timerOfAttack >= timeToAttack)
            {
                attacking = true;
                timerOfAttack = 0;
            }
            if (timerOfSmoke >= timeToSmoke)
            {
                StartCoroutine(startSmoking());
            }
            if (gettingUp)
            {
                getUp();
            }
            else
            {
                smokeOfCigars.emissionRate = 0;
                underSurfaceLevel = new Vector3(transform.position.x, underSurfaceLevel.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, underSurfaceLevel, Time.deltaTime * speedOfMoving);
            }
            if (attacking)
            {
                gettingUp = true;
                if (distance < distanceOfAttack)
                {
                    StartCoroutine(startAttack());
                }
                else
                {
                    follow();
                }
            }
            else
            {
                stopAttack();
                gettingUp = false;
            }
            lastHealth = health.hp;
        }
        else
        {
            StopAllCoroutines();
            transform.position = Vector3.MoveTowards(transform.position, underSurfaceLevel, Time.deltaTime * speedOfMoving);
            transform.rotation = Wyperian.lookAtSlowly(transform, transform.position + Vector3.up * 3, speedOfRot * Time.deltaTime * 20);
            largeSmoke.emissionRate = 0;
            StartCoroutine(stopSmokingplz());

        }

    }
    IEnumerator stopSmokingplz()
    {
        yield return new WaitForSeconds(1);
        smokeOfCigars.emissionRate = 0;
        largeSmoke.emissionRate = 0;
    }
    void follow()
    {
        Vector3 playerPos = new Vector3(player.position.x, surfaceLevel.y, player.position.z);
        transform.rotation = Wyperian.lookAtSlowly(transform, player.position, speedOfRot * Time.deltaTime * 100);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * speedOfMoving);
    }
    IEnumerator startAttack()
    {
        an.SetBool("attack", true);
        an.SetInteger("attackanim", Random.RandomRange(0, 3));
        yield return new WaitForSeconds(1);
        attacking = false;
    }
    IEnumerator startSmoking()
    {
        largeSmoke.emissionRate = 0;
        yield return new WaitForSeconds(2);
        smokeOfCigars.emissionRate = 0;
        largeSmoke.emissionRate = largeSmokeEmission;
        yield return new WaitForSeconds(30);
        largeSmoke.emissionRate = 0;
    }
    void stopAttack()
    {
        an.SetBool("attack", false);
    }
    void getUp()
    {
        surfaceLevel = new Vector3(transform.position.x, surfaceLevel.y, transform.position.z);
        transform.rotation = Wyperian.lookAtSlowly(transform, player.position, speedOfRot * Time.deltaTime * 100);
        transform.position = Vector3.MoveTowards(transform.position, surfaceLevel, Time.deltaTime * speedOfMoving);
    }
}
