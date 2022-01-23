using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesGameMission : GameMission
{
    //Mision
    public int enemiesMustKill;
    private int currentKill = 0;

    //UI
    public Text text;

    public override bool IsCompleteMission()
    {
        return currentKill >= enemiesMustKill;
    }
    public override int CountStar()
    {
        if (currentKill >= enemiesMustKill + 1) return 1;
        if (currentKill >= enemiesMustKill + 2) return 2;
        if (currentKill >= enemiesMustKill + 3) return 3;
        return 0;
    }
    public override void KillNewEnemy(GameObject gameObject)
    {
        if (gameObject.name.Contains("Huntress"))
        {
            currentKill++;
            text.text = currentKill + "/" + enemiesMustKill + ":" + CountStar();
        }
    }
}

