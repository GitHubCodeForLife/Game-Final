using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMission :MonoBehaviour
{
    public virtual bool IsCompleteMission() { return false; }
    public virtual void KillNewEnemy(GameObject gameObject) { }
    public virtual int CountStar() { return 0; }
}
