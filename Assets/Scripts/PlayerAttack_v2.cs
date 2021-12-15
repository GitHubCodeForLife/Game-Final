using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack_v2 : MonoBehaviour
{
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
 
    public float attackRange = 5;
    public int attackDamage = 50;
    public float grenadeTime = 1f;
    public float attackTime = 0.5f;
    private float currentAttackTime;
    private GrenadeFactory grenadeFactory;
    private string grenadeType;

 
    // Start is called before the first frame update
    void Awake()
    {
        currentAttackTime = 0;
        animator = GetComponent<Animator>();
        InitialWeapon();
    }
    private void InitialWeapon()
    {
        //Read  Grenade form Local Storage
        grenadeFactory = FindObjectOfType<GrenadeFactory>();
        grenadeType = "IceGrenade";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAttackTime <= 0)
        {
            currentAttackTime = attackTime;
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.G) && grenadeTime <= 0)
        {
            ThrowGrenade();
            grenadeTime = 1f;
        }
        grenadeTime = grenadeTime - Time.deltaTime < 0 ? 0 : grenadeTime - Time.deltaTime;

        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
    }
    private void ThrowGrenade()
    {
        int direction = transform.rotation.y == 0 ? 1 : -1;
        grenadeFactory.SpawnGrenade(attackPoint.position, attackPoint.rotation, new Vector2(direction * 5, 5), grenadeType);
    }

    void Attack()
    {
        //Play attack animaiton
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log(hitEnemies.Length);
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

