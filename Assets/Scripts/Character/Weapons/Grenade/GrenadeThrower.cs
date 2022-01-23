using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : Thrower
{
    public override GameObject ThrowGrenade(GameObject grenadePrefabs, Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        GameObject grenade = Instantiate(grenadePrefabs, pos, rotation);
        grenade.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        return grenade;
    }
}
