using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject impactEffect;
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet : " + collision.gameObject.name);
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Effect")) return;
        Vector2 pos = transform.position;
        Quaternion quaternion = transform.rotation;

        quaternion.y = transform.localScale.x == 1 ? 0 : 180;

        GameObject impactObject = Instantiate(impactEffect, pos, quaternion);

        Destroy(gameObject);
        if (collision.CompareTag("Enemies"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) enemy.Freeze();
            bool isCrit = GameRandom.RandomCriteRate();
            //Random Rate
            //Crit Damage or Not
            if (isCrit)
                collision.GetComponent<EnemyHealth>().TakeCritDamage(damage * 2);
            else
                collision.GetComponent<EnemyHealth>().TakeNormalDamage(damage);
        }
    }
}