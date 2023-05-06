using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private GameObject soundPrefab;

    public enum Sound
    {
        BoatMove,
        CannonShoot,
        BulletHit,
        BoatDie,
        Pickup
    }

    private static Dictionary<Sound, float> soundTimer;
    private static Dictionary<GameObject, float> soundHolders;

    public static void Initialize()
    {
        soundTimer = new Dictionary<Sound, float>();
        soundTimer[Sound.BoatMove] = 0f;
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySound(AudioClip sound)
    {
        GameObject soundHolder = Instantiate(soundPrefab);
        AudioSource audioSource = soundHolder.GetComponent<AudioSource>();
        DestroyAfterTime d = soundHolder.GetComponent<DestroyAfterTime>();
        audioSource.PlayOneShot(sound);
        // soundHolders.Add(soundHolder, audioSource.clip.length); // might not need this line anymore
        d.timeToDestroy = sound.length; // gives no reference error
    }

    public void PlaySoundAtPosition(AudioClip sound, Vector3 position)
    {
        GameObject soundHolder = Instantiate(soundPrefab, position, Quaternion.identity);
        AudioSource audioSource = soundHolder.GetComponent<AudioSource>();
        DestroyAfterTime d = soundHolder.GetComponent<DestroyAfterTime>();
        audioSource.PlayOneShot(sound);
        // soundHolders.Add(soundHolder, audioSource.clip.length); // might not need this line anymore
        d.timeToDestroy = sound.length;
    }

    // private bool CanPlaySound(Sound sound)
    // {
    //     switch (sound) {
    //     default:
    //         return true;
    //     case Sound.BoatMove:
    //         if(soundTimer.ContainsKey(sound)) {
    //             float lastTimePlayed = soundTimer[sound];
    //             float playerMoveTimerMax = .05f;
    //             if(lastTimePlayed + playerMoveTimerMax < Time.time) {
    //                 soundTimer[sound] = Time.time;
    //                 return true;
    //             }
    //         }
    //     }
    // }
}
