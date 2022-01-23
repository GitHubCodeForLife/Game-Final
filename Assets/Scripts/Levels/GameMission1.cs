using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMission1 : GameMission
{
    //Mision
    public int enemiesMustKill;
    private int currentKill =0;

    //UI
    public Text text;

    private void Awake()
    {
        currentKill = 0;
    }
    private void Start()
    {
        text.text = currentKill + "/" + enemiesMustKill +":" + CountStar();
    }
    public override void KillNewEnemy(GameObject gameObject)
    {
        currentKill++;
        text.text = currentKill + "/" + enemiesMustKill+":" + CountStar();
    }
    public override bool IsCompleteMission()
    {
        return currentKill >= enemiesMustKill;
    }
    public override int CountStar()
    {
        if (currentKill >= enemiesMustKill + 1) return 1;
        if (currentKill >= enemiesMustKill + 2) return 2;
        if (currentKill >= enemiesMustKill + 3) return 3;
        if (currentKill >= enemiesMustKill + 4) return 4;
        return 0;
    }
}
