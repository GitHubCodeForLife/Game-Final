using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;

    public float attackRange = 5;
    public int attackDamage = 30;

    public float FireSpeedTime = 0.5f;
    public float grenadeTime = 1f;
    private float currentFireTime;
    public float attackTime = 0.5f;
    private float currentAttackTime;

    private GrenadeFactory grenadeFactory;
    private GunFactory gunFactory;
    private Gun gun;
    private string grenadeType;
    // Start is called before the first frame update
    void Awake()
    {
        currentFireTime = 0;
        currentAttackTime = 0;
        animator = GetComponent<Animator>();
        InitialWeapon();
    }

    private void InitialWeapon()
    {
        grenadeFactory = FindObjectOfType<GrenadeFactory>();
        gunFactory = GameObject.FindObjectOfType<GunFactory>();
        //Read information from Local Storage 
        gun = gunFactory.CreateGun("ThreeGun");
        grenadeType = "NormalGrenade";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAttackTime <= 0)
        {
            currentAttackTime = attackTime;
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.F) && currentFireTime <= 0)
        {
            Shoot();
            currentFireTime = FireSpeedTime;
        }
        if (Input.GetKeyDown(KeyCode.G) && grenadeTime <= 0)
        {
            ThrowGrenade();
            grenadeTime = 1f;
        }
        currentFireTime = currentFireTime - Time.deltaTime < 0 ? 0 : currentFireTime - Time.deltaTime;
        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
        grenadeTime = grenadeTime - Time.deltaTime < 0 ? 0 : grenadeTime - Time.deltaTime;
    }

    private void ThrowGrenade()
    {
        int direction = transform.rotation.y == 0 ? 1 : -1;
        grenadeFactory.SpawnGrenade(attackPoint.position, attackPoint.rotation ,new Vector2(direction*5, 5), grenadeType);
    }

    void Attack()
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
            Debug.Log("Player Attack Slice: " +enemy.name);
        }

    }
    void Shoot()
    {
        animator.SetBool("IsUsingGun", true);
        animator.SetBool("Shoot", true);
        int direction = transform.rotation.y == 0 ? 1 : -1;
        Vector2 velocityBullet = new Vector2( direction * 10, 0);
        gun.SpawnBullet(attackPoint.position, attackPoint.rotation, velocityBullet);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
