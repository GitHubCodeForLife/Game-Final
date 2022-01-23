using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class LevelInfo 
{
    public string name;
    public int stars; // -1 0 1 2 3
    public LEVEL_STATE state;
}

public enum LEVEL_STATE
{
    PASSED, LOCK, OPENING 
}
