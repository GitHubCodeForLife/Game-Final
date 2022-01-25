using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvancedAttack : PlayerAttack
{
    protected override void SetAnimAttack()
    {
        Debug.Log("Player Advanced Attack");
        animator.SetBool("IsUsingGun", false);
        animator.SetTrigger("Slash");
    }
    public override void Attack()
    {
        //Detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
     
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeCritDamage(attackDamage);
    
            Chest chest = enemy.GetComponent<Chest>();
            if (chest != null)
                chest.OpenChest();
        }

    }
    protected override void Shoot()
    {
        animator.SetBool("IsUsingGun", true);
        animator.SetBool("Shoot", true);
        float direction = transform.localScale.x;
        Vector2 velocityBullet = new Vector2(direction * 10, 0);
        gun.SpawnBullet(bulletPrefab, attackPoint.position, attackPoint.rotation, velocityBullet);
    }
    protected override void ThrowGrenade()
    {
        Vector3 t = new Vector2(transform.localScale.x * 0.5f, 0.5f);
        thrower.ThrowGrenade(grenadePrefabs, attackPoint.position + t, attackPoint.rotation, new Vector2(transform.localScale.x * 5, 5));
        //Debug.Log("Player Advanec Attack - Throw Grenade");
        //int direction = transform.rotation.y == 0 ? 1 : -1;
        //thrower.ThrowGrenade(grenadePrefabs, attackPoint.position, attackPoint.rotation, new Vector2(direction * 5, 5));
    }

}
