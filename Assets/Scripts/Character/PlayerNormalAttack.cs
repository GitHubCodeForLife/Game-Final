using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : PlayerAttack
{
    protected override void InitialWeapon()
    {
        grenadeFactory = FindObjectOfType<GrenadeFactory>();
        gunFactory = FindObjectOfType<GunFactory>();

        grenadeThrower = new GrenadeThrower();

        grenadePrefabs = grenadeFactory.GetGrenade("Boom 01");

        ////Read information from Local Storage 
        gun = gunFactory.CreateGun("ThreeGun");
        //gun = gunFactory.CreateGun("NormalGun");
    }


    protected override void Attack()
    {
        //Play attack animaiton
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Debug.Log(hitEnemies.Length);
        if (hitEnemies.Length >= 1)
        {
            // Instantiate(impactEffect, attackPoint.position, attackPoint.rotation);
        }
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeCritDamage(attackDamage);
            Debug.Log("Player Attack Slice: " + enemy.name);
        }

    }
    protected override void Shoot()
    {
        int direction = transform.rotation.y == 0 ? 1 : -1;
        Vector2 velocityBullet = new Vector2(direction * 10, 0);
        gun.SpawnBullet(attackPoint.position, attackPoint.rotation, velocityBullet);
    }

    protected override void ThrowGrenade()
    {
        int direction = transform.rotation.y == 0 ? 1 : -1;
        grenadeThrower.ThrowGrenade(grenadePrefabs, attackPoint.position, attackPoint.rotation, new Vector2(direction * 5, 5));
    }
}
