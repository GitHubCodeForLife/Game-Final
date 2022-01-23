using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGun : Gun
{
    private const float distance = 0.25f;

    public override void SpawnBullet(GameObject bulletPrefab, Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        base.SpawnBullet(bulletPrefab, pos + new Vector3(0, distance, 0), rotation, new Vector2(velocity.x, velocity.y));
        base.SpawnBullet(bulletPrefab, pos + new Vector3(0, -distance, 0), rotation, new Vector2(velocity.x, velocity.y));
    }
}
