using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChest : Chest
{
    public override void SpawnTreasure()
    {
        Debug.Log("Gold Chest Spawn Treaserue");

        SpawnEffect.instance.SpawnTreasures(transform.position, SpawnEffect.blackChestRates, 10);
    }
}
