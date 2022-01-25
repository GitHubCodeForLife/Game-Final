using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Farm : GameMission
{
    //Mision
    public int enemiesMustKill=10;
    private int currentKill = 0;

    //UI
    public Text text;
    public Text Star;
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
        if (gameObject.name.Contains("Huntress") 
        || gameObject.name.Contains("Bull")
        || gameObject.name.Contains("Light")
        || gameObject.name.Contains("Minotaur ")
         || gameObject.name.Contains("Hyena")
        || gameObject.name.Contains("Minotaur"))
        {
            currentKill++;
            text.text = currentKill + "/" + enemiesMustKill ;
            Star.text = "Current Star : " + CountStar();
        }
       
       
    }
}

