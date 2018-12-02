using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayOnceAndLoop : MonoBehaviour
{
    private AudioSource aS;

    public AudioClip introAudio;
    public AudioClip loopAudio;
    private void Awake()
    {
        aS = this.GetComponent<AudioSource>();
        aS.clip = introAudio;
        aS.loop = false;
    }

    private void Update()
    {
        if (aS.isPlaying)
            return;
        aS.clip = loopAudio;
        aS.loop = true;
        aS.Play();
        this.enabled = false;
    }
}
