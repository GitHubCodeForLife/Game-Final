using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;
    
    [Range(0, 1)]
    public float volume;
    [Range(-3f,3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public void Setting()
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
    }

}