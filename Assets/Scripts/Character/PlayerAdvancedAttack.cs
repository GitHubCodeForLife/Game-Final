using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvancedAttack : PlayerAttack
{
    protected override void Attack()
    {
        //Play attack animaiton
        animator.SetBool("IsUsingGun", false);
        animator.SetTrigger("Slash");
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
        animator.SetBool("IsUsingGun", true);
        animator.SetBool("Shoot", true);
        int direction = transform.rotation.y == 0 ? 1 : -1;
        Vector2 velocityBullet = new Vector2(direction * 10, 0);
        gun.SpawnBullet(bulletPrefab, attackPoint.position, attackPoint.rotation, velocityBullet);
    }
    protected override void ThrowGrenade()
    {
        Debug.Log("Player Advanec Attack - Throw Grenade");
        int direction = transform.rotation.y == 0 ? 1 : -1;
        thrower.ThrowGrenade(grenadePrefabs, attackPoint.position, attackPoint.rotation, new Vector2(direction * 5, 5));
    }

}
