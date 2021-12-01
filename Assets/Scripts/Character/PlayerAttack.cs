using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public GameObject impactEffect;
    public float attackRange = 5;
    public int attackDamage = 30;

    public float FireSpeedTime = 0.5f;
    private float currentFireTime;
    public float attackTime = 0.5f;
    private float currentAttackTime;


    // Start is called before the first frame update
    void Awake()
    {
        currentFireTime = 0;
        currentAttackTime = 0;
        animator = GetComponent<Animator>();
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
            //Shoot
            Shoot();
            currentFireTime = FireSpeedTime;
        }
        currentFireTime = currentFireTime - Time.deltaTime < 0 ? 0 : currentFireTime - Time.deltaTime;
        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
    }
    void Attack()
    {
        //Play attack animaiton
        animator.SetBool("IsUsingGun", false);
        animator.SetTrigger("Slash");
        //Detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log(hitEnemies.Length);
        if (hitEnemies.Length >= 1)
        {
            Instantiate(impactEffect, attackPoint.position, attackPoint.rotation);
        }
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log(enemy.name);
        }

    }
    void Shoot()
    {
        animator.SetBool("IsUsingGun", true);
        animator.SetBool("Shoot", true);
        // Debug.Log(attackPoint.rotation.eulerAngles);
        //Debug.Log(attackPoint.rotation.x);

        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
       
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
