using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeGun : Gun
{
    public override void SpawnBullet(GameObject bulletPrefab, Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        base.SpawnBullet(bulletPrefab, pos, rotation, velocity);
        base.SpawnBullet(bulletPrefab, pos, rotation, new Vector2(velocity.x, velocity.x));
        base.SpawnBullet(bulletPrefab, pos, rotation, new Vector2(velocity.x, -velocity.x));
    }
}
