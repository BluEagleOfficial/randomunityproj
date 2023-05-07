using UnityEngine;

public class randomAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;

    [SerializeField]
    AudioSource asource;

    [SerializeField]
    float pitchMin = 1, pitchMax = 1;
    void Start()
    {
        asource.Stop();
        asource.clip = clips[Random.Range(0, clips.Length)];
        asource.pitch = Random.Range(pitchMin, pitchMax);
        asource.Play();
    }
}
