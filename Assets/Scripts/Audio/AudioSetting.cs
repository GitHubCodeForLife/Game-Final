using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetting : MonoBehaviour
{
    public AudioMixer audioBgMixer;

    public AudioMixer audioEffectMixer;

    private void Awake()
    {
        float bg, effect;
        bg = GameStorageManager.gameInfo.bgAudioMixer ;
        effect = GameStorageManager.gameInfo.effectAudioMixer;
        audioBgMixer.SetFloat("bg",  bg);
        audioEffectMixer.SetFloat("effect", effect);
    }
}
