using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private GameObject soundPrefab;

    // public enum Sound
    // {
    //     BoatMove,
    //     CannonShoot,
    //     BulletHit,
    //     BoatDie,
    //     Pickup
    // }

    // private static Dictionary<Sound, float> soundTimer;
    public List<AudioSource> soundHolders = new List<AudioSource>();
    // private static List<AudioClip> soundHolderz = new List<AudioClip>();

    // public static void Initialize()
    // {
    //     soundTimer = new Dictionary<Sound, float>();
    //     soundTimer[Sound.BoatMove] = 0f;
    // }

    void Awake()
    {
        if (Instance == null)
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
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.PlayOneShot(sound);
        soundHolders.Add(audioSource);
        d.timeToDestroy = sound.length;
    }

    public void PlaySoundAtPosition(AudioClip sound, Vector3 position)
    {
        GameObject soundHolder = Instantiate(soundPrefab, position, Quaternion.identity);
        AudioSource audioSource = soundHolder.GetComponent<AudioSource>();
        DestroyAfterTime d = soundHolder.GetComponent<DestroyAfterTime>();
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.PlayOneShot(sound);
        soundHolders.Add(audioSource);
        d.timeToDestroy = sound.length;
    }
    public void PlaySoundAtPosition(AudioClip sound, Vector3 position, float volume, float distance)
    {
        GameObject soundHolder = Instantiate(soundPrefab, position, Quaternion.identity);
        AudioSource audioSource = soundHolder.GetComponent<AudioSource>();
        DestroyAfterTime d = soundHolder.GetComponent<DestroyAfterTime>();
        audioSource.maxDistance = distance;
        audioSource.volume = volume;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.PlayOneShot(sound);
        soundHolders.Add(audioSource);
        d.timeToDestroy = sound.length;
    }

    public void StopSound(AudioClip sound)
    {
        for (int i = 0; i < soundHolders.Count; i++)
        {
            // AudioSource as = soundHolders[i].GetComponent<AudioSource>();

            if (soundHolders[i].clip == sound)
            {
                Debug.Log("DESTROY SOUND " + soundHolders[i].gameObject.name);
                // Destroy(soundHolders[i].gameObject);
                // soundHolders[i].enabled = false;
                soundHolders[i].Stop();
                soundHolders.RemoveAt(i);
            }
        }
    }

    public bool SoundIsPlaying(AudioClip sound)
    {
        for (int i = 0; i < soundHolders.Count; i++)
        {
            if (soundHolders[i].clip == sound)
            {
                return true;
            }
        }
        return false;
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
