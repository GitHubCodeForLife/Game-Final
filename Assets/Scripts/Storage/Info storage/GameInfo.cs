
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameInfo 
{
    public List<LevelInfo> levels;
    public PlayerInfo playerInfo;
    public float effectAudioMixer;
    public float bgAudioMixer;
    public bool isPassIntro;
}
