using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class RandomPitchAlteration : MonoBehaviour
{
    [SerializeField]
    private float maxPitch=1.1f;
    [SerializeField]
    private float minPitch=0.9f;

    private int lastSamples;
    public void OnValidate()
    {
        if(maxPitch < minPitch)
        {
            minPitch = maxPitch;
        }
    }

    private AudioSource aS;
    private void Awake()
    {
        aS = this.GetComponent<AudioSource>();
        aS.pitch = Random.Range(minPitch, maxPitch);
    }

    private void Update()
    {
        int samples;
        samples = aS.timeSamples;
        if(samples<lastSamples)
            aS.pitch = Random.Range(minPitch, maxPitch);
        lastSamples = aS.timeSamples;
        
    }

}
