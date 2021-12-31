using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public List<GameObject> bullets;
    public GameObject GetBullets(int index)
    {
        return bullets[index];
    }
    public GameObject GetBullets(string name)
    {
        Debug.Log("Bullet Factory - Get Bullets " + name);
        return bullets[1];
    }
}
