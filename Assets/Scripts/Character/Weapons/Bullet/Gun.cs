using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public virtual void SpawnBullet(GameObject bulletPrefab, Vector3 pos, Quaternion rotation, Vector2 velocity)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = velocity;
        float direction = velocity.x > 0 ? 1 : -1;
        bullet.transform.localScale = new Vector3(direction,1,1);
    }
}
