using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // public AudioClip Music;
    public int volume;
    public List<AudioClip> Musics = new List<AudioClip>();
    [SerializeField] private AudioSource source;
    public bool playRandom = true;
    public bool killMusicOnSceneChange;

    void Start()
    {
        // source.PlayOneShot(Music);
    }

    void Update()
    {
        if(!source.isPlaying)
        {
            if(playRandom)
                source.PlayOneShot(Musics[Random.Range(0,Musics.Count)]);
            else
                source.PlayOneShot(Musics[0]);
        }
        
        // if(MenuManager.gamePaused)
        //     PauseMusic(source.clip);
        // else
        //     ResumeMusic(source.clip);
    }

    public void PlayMusic(AudioClip music)
    {
        source.Stop();
        source.PlayOneShot(music);
    }

    public void PauseMusic(AudioClip music)
    {
        source.Pause();
    }

    public void ResumeMusic(AudioClip music)
    {
        source.UnPause();
    }

    public void StopMusic(AudioClip music)
    {
        source.Stop();
    }
}
