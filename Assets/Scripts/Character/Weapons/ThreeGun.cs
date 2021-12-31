using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeGun : Gun
{

    public override void SpawnBullet( Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        base.SpawnBullet(pos, rotation, velocity);
        base.SpawnBullet(pos, rotation, new Vector2(velocity.x, velocity.x));
        base.SpawnBullet(pos, rotation, new Vector2(velocity.x, -velocity.x));
    }
}
