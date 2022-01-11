using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;


    [Header("Attack Setting")]
    public float attackRange = 5;
    public int attackDamage = 30;
    public float range = 0.5f;
    public float attackTime = 0.5f;
    private float currentAttackTime;
    //public GameObject attackEffect;

    [Header("Gun setting")]
    public float FireSpeedTime = 0.5f;
    private float currentFireTime;

    [Header("Grenade Setting")]
    public float grenadeTime = 1f;
    private float currentGrenade;


    protected GrenadeFactory grenadeFactory;
    protected Thrower thrower;
    protected GameObject grenadePrefabs;
    private int numberOfGrenade = 10;

    protected BulletFactory bulletFactory;
    protected Gun gun;
    protected GameObject bulletPrefab;
    private int numberOfBullet = 20;

    // Start is called before the first frame update
    void Awake()
    {
        currentFireTime = 0;
        currentAttackTime = 0;
        currentGrenade = 0;
        animator = GetComponent<Animator>();
        InitialWeapon();
    }

    private void InitialWeapon()
    {
        grenadeFactory = FindObjectOfType<GrenadeFactory>();
        bulletFactory = FindObjectOfType<BulletFactory>();

        thrower = new GrenadeThrower();
        gun = new NormalGun();
        // thrower =  gameObject.AddComponent<GrenadeThrower>();
        //gun = gameObject.AddComponent<NormalGun>();

        Debug.Log("Player Advance Attack - Grenade type " + GameStorageManager.GetSelectedGrenade());
        Debug.Log("Player Advance Attack - Gun type " + GameStorageManager.GetSelectedGun());
        grenadePrefabs = grenadeFactory.GetGrenade(GameStorageManager.GetSelectedGrenade());
        bulletPrefab = bulletFactory.GetBullet(GameStorageManager.GetSelectedGun());
        //bulletPrefab = bulletFactory.GetBullet("Water Gun");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAttackTime <= 0)
        {
            currentAttackTime = attackTime;
            animator.SetTrigger("Attack");
            //Attack();
        }
        if (Input.GetKeyDown(KeyCode.F) && currentFireTime <= 0 && bulletPrefab!=null)
        {
            Shoot();
            currentFireTime = FireSpeedTime;
        }
        if (Input.GetKeyDown(KeyCode.G) && currentGrenade <= 0 && grenadePrefabs != null)
        {
            ThrowGrenade();
            currentGrenade = grenadeTime;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Test Die");
            animator.SetTrigger("Hurt");
        }
        currentFireTime = currentFireTime - Time.deltaTime < 0 ? 0 : currentFireTime - Time.deltaTime;
        currentAttackTime = currentAttackTime - Time.deltaTime < 0 ? 0 : currentAttackTime - Time.deltaTime;
        currentGrenade = currentGrenade - Time.deltaTime < 0 ? 0 : currentGrenade - Time.deltaTime;
    }

    protected virtual void ThrowGrenade()
    {}
    public virtual void Attack()
    {
    
    }
    protected virtual void Shoot()
    {}
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Vector3 t = new Vector2(range*transform.localScale.x, 0);
        Gizmos.DrawWireSphere(attackPoint.position + t, attackRange);
    }
    public void ChangeGun(string item)
    {
        if (item == "S")
            gun = new ThreeGun();
    }
    public void ChangeGrenadeThrower(string item)
    {
        if (item == "S")
            gun = new ThreeGun();
    }
}
