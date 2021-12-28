using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public List<AbilityInfo> selectedAbility;
    public WeaponInfo gun;
    public WeaponInfo grenade;
    public CharacterInfo selectedCharacter;
    public int gold;
    public int level;
}