using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopInfo
{
    public List<CharacterInfo> characters;
    public List<GunInfo> guns;
    public List<GrenadeInfo> grenades;
    public List<AbilityInfo> abilities;
}
