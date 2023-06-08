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
    ParticleSystem farts;
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

    float normalEmission = 0, fartsEmission = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(enemyTag).transform;
        normalEmission = smokeOfCigars.emissionRate;
        fartsEmission = farts.emissionRate;
        farts.emissionRate = 0;
    }
    float distance = 0;

    bool alive = true;
    int lastHealth = 0;
    void Update()
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
    void follow()
    {
        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.rotation = Wyperian.lookAtSlowly(transform, player.position, speedOfRot * Time.deltaTime * 100);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * speedOfMoving);
    }
    IEnumerator startAttack()
    {
        an.SetBool("attack", true);
        yield return new WaitForSeconds(1);
        attacking = false;
    }
    IEnumerator startSmoking()
    {
        smokeOfCigars.emissionRate = normalEmission * 50;
        farts.emissionRate = 0;
        yield return new WaitForSeconds(2);
        smokeOfCigars.emissionRate = 0;
        farts.emissionRate = fartsEmission;
        yield return new WaitForSeconds(30);
        farts.emissionRate = 0;
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
