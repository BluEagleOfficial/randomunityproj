using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform aimer;

    public Transform tip;
    public Transform cannonHead;

    public float speedOfRot = 5;

    void FixedUpdate()
    {
        cannonHead.rotation = Wyperian.lookAtSlowly(cannonHead, aimer.position, Time.deltaTime * speedOfRot * 100);

    }

    public void shoot()
    {
        Instantiate(bulletPrefab, tip.position, cannonHead.rotation);
    }
}
