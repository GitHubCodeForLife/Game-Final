using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : PlayerAttack
{
    public override void Attack()
    {
        //Detect enemies in range of attack 
        Vector3 t = new Vector2(range * transform.localScale.x, 0);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position + t, attackRange, enemyLayers);
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeCritDamage(attackDamage);
        }
    }
    protected override void Shoot()
    {
        float direction = transform.localScale.x;
        Vector2 velocityBullet = new Vector2(direction * 10, 0);
        gun.SpawnBullet(bulletPrefab, attackPoint.position, attackPoint.rotation, velocityBullet);
    }

    protected override void ThrowGrenade()
    {
        Vector3 t = new Vector2(transform.localScale.x*0.5f, 0.5f);
        thrower.ThrowGrenade(grenadePrefabs, attackPoint.position + t, attackPoint.rotation, new Vector2(transform.localScale.x * 5, 5));
    }

}
