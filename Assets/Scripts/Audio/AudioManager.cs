using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); return;
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.Setting();

        }
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
        if (s != null)
            s.source.PlayOneShot(s.clip);
        else
            Debug.LogWarning("Sound: " + name + " not found!");
    }

    internal void Stop(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == audioName);
        s.source.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
        if (s != null)
            s.source.Stop();
        else
            Debug.LogWarning("Sound: " + name + " not found!");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
        if (s != null)
            s.source.Play();
        else
            Debug.LogWarning("Sound: " + name + " not found!");
    }
}
