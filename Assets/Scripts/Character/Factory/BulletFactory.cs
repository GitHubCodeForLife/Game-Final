using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public List<GameObject> bullets;
    public GameObject GetBullets(int index)
    {
        return bullets[index];
    }
    public GameObject GetBullet(string name)
    {
        Debug.Log("Bullet Factory - Get Bullets " + name);
        int index = GetBulletIndex(name);
        return bullets[index];
    }
    private int GetBulletIndex(string name)
    {
        int index = 0;
        foreach (GameObject gun in bullets)
        {
            //Debug.Log("GunFactory " + gun.name + " vs " + name + " Result "+ gun.name.Equals(name) ); 
            if (gun.name.Equals(name)) return index;
            index++;
        }
        return 0;
    }
}
