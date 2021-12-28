using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;

    public float attackRange = 5;
    public int attackDamage = 30;

    public float FireSpeedTime = 0.5f;
    private float currentFireTime;

    public float grenadeTime = 1f;
    private float currentGrenade;

    public float attackTime = 0.5f;
    private float currentAttackTime;

    protected GrenadeFactory grenadeFactory;
    protected GunFactory gunFactory;
    protected Gun gun;
    protected string grenadeType;
    // Start is called before the first frame update
    void Awake()
    {
        currentFireTime = 0;
        currentAttackTime = 0;
        currentGrenade = 0;
        animator = GetComponent<Animator>();
        InitialWeapon();
    }

    protected virtual void InitialWeapon()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAttackTime <= 0)
        {
            currentAttackTime = attackTime;
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.F) && currentFireTime <= 0 && gun!=null)
        {
            Shoot();
            currentFireTime = FireSpeedTime;
        }
        if (Input.GetKeyDown(KeyCode.G) && currentGrenade <= 0 && grenadeType!=null)
        {
            ThrowGrenade();
            currentGrenade = grenadeTime;
        }
        currentFireTime = currentFireTime - Time.deltaTime < 0 ? 0 : currentFireTime - Time.deltaTime;
        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
        currentGrenade = currentGrenade - Time.deltaTime < 0 ? 0 : currentGrenade - Time.deltaTime;
    }

    protected virtual void ThrowGrenade()
    {}
    protected virtual void Attack()
    {}
    protected virtual void Shoot()
    {}
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
