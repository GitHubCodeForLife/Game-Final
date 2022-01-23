using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFactory : MonoBehaviour
{
    public List<GameObject> grenades;

    public GameObject GetGrenade(string name)
    {
        int index = GetGranadeIndex(name);
        return grenades[index];
    }

    private int GetGranadeIndex(string name)
    {
        int index = 0;
        foreach (GameObject granade in grenades)
        {
            //Debug.Log("Grenade Factory " + granade.name + " vs " + name + " Result " + grenades[index].name.Equals(name));
            if (granade.name.Equals(name)) return index;
            index++;
        }
        return 0;
    }
}
