using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponInfo 
{
    public string name;
    public WEAPON_TYPE type;//Gun and grenade
    public int price;
    public string ability;
    public STATE_ITEM state;
}

