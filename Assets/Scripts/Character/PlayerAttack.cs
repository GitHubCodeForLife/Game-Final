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

    internal void PowerDamage()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = Color.red;
        attackDamage *= 2;
    }

    //public GameObject attackEffect;

    [Header("Gun setting")]
    public float FireSpeedTime = 0.5f;
    private float currentFireTime;
    private int bulletNumber = 10;

    [Header("Grenade Setting")]
    public float grenadeTime = 1f;
    private float currentGrenade;
    private int grenadeNumber = 5;


    protected GrenadeFactory grenadeFactory;
    protected Thrower thrower;
    protected GameObject grenadePrefabs;


    protected BulletFactory bulletFactory;
    protected Gun gun;
    protected GameObject bulletPrefab;

    internal void ChangeBullet()
    {
       bulletPrefab = bulletPrefab = bulletFactory.GetBullet("IceBullet");
    }


    // Start is called before the first frame update
    void Awake()
    {
        currentFireTime = 0;
        currentAttackTime = 0;
        currentGrenade = 0;
        animator = GetComponent<Animator>();
        InitialWeapon();
    }
    private void Start()
    {

        HUDPlayer.instance.SetBullet(bulletNumber);
        HUDPlayer.instance.SetGrenade(grenadeNumber);

    }

    private void InitialWeapon()
    {
        grenadeFactory = FindObjectOfType<GrenadeFactory>();
        bulletFactory = FindObjectOfType<BulletFactory>();

        thrower = new GrenadeThrower();
        gun = new Gun();
 
        Debug.Log("Player Advance Attack - Grenade type " + GameStorageManager.GetSelectedGrenade());
        Debug.Log("Player Advance Attack - Gun type " + GameStorageManager.GetSelectedGun());

        grenadePrefabs = grenadeFactory.GetGrenade(GameStorageManager.GetSelectedGrenade());
        bulletPrefab = bulletFactory.GetBullet(GameStorageManager.GetSelectedGun());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAttackTime <= 0)
        {
            currentAttackTime = attackTime;
            SetAnimAttack();
            //Attack();
        }
        if (Input.GetKeyDown(KeyCode.F) && currentFireTime <= 0 && bulletPrefab != null && bulletNumber > 0)
        {
            bulletNumber--;
            HUDPlayer.instance.SetBullet(bulletNumber);
            Shoot();
            currentFireTime = FireSpeedTime;
        }
        if (Input.GetKeyDown(KeyCode.G) && currentGrenade <= 0 && grenadePrefabs != null && grenadeNumber > 0)
        {
            grenadeNumber--;
            HUDPlayer.instance.SetGrenade(grenadeNumber);
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

    protected virtual void SetAnimAttack()
    {
        animator.SetTrigger("Attack");
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
        if (item == "Gun")
            gun = new Gun();
        if (item == "TwoGun")
            gun = new TwoGun();
        if (item == "ThreeGun")
            gun = new ThreeGun();
        bulletNumber = 10;
        HUDPlayer.instance.SetBullet(bulletNumber);
    }
    public void ChangeGrenadeThrower(string item)
    {
       // if (item == "S")
        //    gun = new ThreeGun();
        grenadeNumber = 10;
        HUDPlayer.instance.SetGrenade(grenadeNumber);
    }
    public void CollectBullet()
    {
        bulletNumber++;
        HUDPlayer.instance.SetBullet(bulletNumber);
    }
    public void CollectGrenade()
    {
        grenadeNumber++;
        HUDPlayer.instance.SetGrenade(grenadeNumber);
    }
    public void Recover()
    {
        bulletNumber = 10;
        grenadeNumber = 5;
        HUDPlayer.instance.SetBullet(bulletNumber);
        HUDPlayer.instance.SetGrenade(grenadeNumber);
    }
}
