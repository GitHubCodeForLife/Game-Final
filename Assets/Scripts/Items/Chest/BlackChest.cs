using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChest : Chest
{
    public override void SpawnTreasure()
    {
        Debug.Log("Black Chest Spawn Treaserue");

        SpawnEffect.instance.SpawnTreasures(transform.position, SpawnEffect.blackChestRates,6);
    }
}
