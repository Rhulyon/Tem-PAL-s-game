using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayOnceAndLoop : MonoBehaviour
{
    private AudioSource aS;

    public AudioClip introAudio;
    public AudioClip loopAudio;

    private bool paused;

    private void Awake()
    {
        aS = this.GetComponent<AudioSource>();
        aS.clip = introAudio;
        aS.loop = false;
        aS.Play();
    }

    public void PauseMusic()
    {
        aS.Pause();
        paused = true;
    }

    public void ResumeMusic()
    {
        aS.UnPause();
        paused = false;

    }

    private void Update()
    {
        if (aS.isPlaying||paused)
            return;
        aS.clip = loopAudio;
        aS.loop = true;
        aS.Play();
        this.enabled = false;
    }
}
