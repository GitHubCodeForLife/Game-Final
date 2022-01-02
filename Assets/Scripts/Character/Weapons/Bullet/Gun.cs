using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public virtual void SpawnBullet(GameObject bulletPrefab, Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
