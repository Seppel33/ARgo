using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource ambienceAudioSource;
    void Start()
    {
        ambienceAudioSource = gameObject.GetComponent<AudioSource>();
        if (GlobalDataManager.ambienceIsPlaying)
        {
            ambienceAudioSource.Play();
        }
        else
        {
            ambienceAudioSource.Stop();
        }
    }
}
