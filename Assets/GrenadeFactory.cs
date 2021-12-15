using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFactory : MonoBehaviour
{
    public List<GameObject> gredanes;

    private int GetGranadeIndex(string name)
    {
        int index = 0;
        foreach (GameObject granade in gredanes)
        {
            Debug.Log("Grenade Factory " + granade.name + " vs " + name + " Result "+ gredanes[index].name.Equals(name) ); 
            if (granade.name.Equals(name)) return index;
            index++;
        }
        return 0;
    }
    public void SpawnGrenade(Vector3 pos, Quaternion rotation, Vector2 velocity, string name)
    {
        int index = GetGranadeIndex(name);
        GameObject granade = Instantiate(gredanes[index], pos, rotation);
        granade.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
    }
}
