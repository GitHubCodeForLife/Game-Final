using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFactory : MonoBehaviour
{
   public List<GameObject> guns;
   public Gun CreateGun(string name)
    {
        int index = GetGunIndex(name);
        Gun gun = Instantiate(guns[index], transform.position, transform.rotation).GetComponent<Gun>();
        return gun;
    }

    private int GetGunIndex(string name)
    {
        int index = 0;
        foreach(GameObject gun in guns)
        {
            //Debug.Log("GunFactory " + gun.name + " vs " + name + " Result "+ gun.name.Equals(name) ); 
            if (gun.name.Equals(name)) return index;
            index++;
        }
        return index;
    }
}
