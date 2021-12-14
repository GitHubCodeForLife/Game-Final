using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack_v2 : MonoBehaviour
{
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
 
    public float attackRange = 5;
    public int attackDamage = 30;

    public float attackTime = 0.5f;
    private float currentAttackTime;


    // Start is called before the first frame update
    void Awake()
    {
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

        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
    }
    void Attack()
    {
        //Play attack animaiton
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log(hitEnemies.Length);
        //if (hitEnemies.Length >= 1)
        //{
        //    int index = (int)Random.Range(1, 4);
        //    GameObject gameObject;
        //    if (index == 1)
        //        gameObject = Instantiate(damageEffect, attackPoint.position, attackPoint.rotation);
        //    else
        //        gameObject = Instantiate(damageCritEffect, attackPoint.position, attackPoint.rotation);
        //    gameObject.GetComponent<DamgeUI>().SetDamage(attackDamage);
        //}
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeCritDamage(attackDamage);
            Debug.Log(enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

