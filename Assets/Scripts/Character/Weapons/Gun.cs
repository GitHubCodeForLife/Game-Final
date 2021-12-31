using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public virtual void SpawnBullet(Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
