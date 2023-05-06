using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private AudioClip cannonShoot;

    public Transform aimer;

    public Transform tip;
    public Transform cannonHead;

    public float speedOfRot = 5;

    public float shootEvery = 1;

    public float timeOfShoot = 0;

    [SerializeField]
    string ignoreTag = "Player";

    void FixedUpdate()
    {
        cannonHead.rotation = Wyperian.lookAtSlowly(cannonHead, aimer.position, Time.deltaTime * speedOfRot * 100);
        timeOfShoot += Time.fixedDeltaTime;
    }

    public void shoot()
    {
        if (timeOfShoot > shootEvery)
        {
            if(cannonShoot != null)
                SoundManager.Instance.PlaySoundAtPosition(cannonShoot, tip.position);
            GameObject g = Instantiate(bulletPrefab, tip.position, cannonHead.rotation);
            g.GetComponent<bullet>().ignoreTag = ignoreTag;
            timeOfShoot = 0;
        }

    }
}
