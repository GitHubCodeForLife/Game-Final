using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelState : MonoBehaviour
{
    [Range(1,20)]
    public int level;
    public Text textLevel;

    public void SetTextLevel(string level)
    {
        textLevel.text = level;
    }
}
