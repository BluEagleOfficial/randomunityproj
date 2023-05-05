using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;


    public enum Sound
    {
        BoatMove,
        CannonShoot,
        BulletHit,
        BoatDie,
        Pickup
    }

    private static Dictionary<Sound, float> soundTimer;

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

    public static void PlaySound(AudioClip sound)
    {
        GameObject soundHolder = new GameObject("Sound");
        AudioSource audioSource = soundHolder.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    // public static void PlaySound(Sound sound)
    // {
    //     if(CanPlaySound(sound))
    //     {
    //         GameObject soundHolder = new GameObject("Sound");
    //         AudioSource audioSource = soundHolder.AddComponent<AudioSource>();
    //         audioSource.PlayOneShot(GetAudioClip(sound));
    //     }
    // }

    // private static bool CanPlaySound(Sound sound)
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
