using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Timer Switching Setting")]
    public float maxIdleTimer;
    public float minIdleTimer;
    public float maxMovingTimer;
    public float minMovingTimer;
    [Header("Enemny Info")]
    public float speed;
    public int damage = 10;
    public  float force = 2;
    [Header("Attack Parameters")]
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    protected PlayerHealth playerHealth;

    [Header("Water Bullet")]
    private const float freezeTime = 10f;
    private float currentFreezeTime = 0f;

    [Header("ICE Bullete")]
    private const float iceTime = 10f;
    private float currentIceTime = 0f;

    Animator animator;
    SpriteRenderer sr;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    public bool IsFreeze()
    {
        return currentFreezeTime > 0;
    }
    private void Update()
    {
        currentFreezeTime = currentFreezeTime > 0 ? currentFreezeTime - Time.deltaTime : 0;
        if (currentFreezeTime <= 0)
        {
            if (animator.enabled != true)
                animator.enabled = true;
        }
        if (currentIceTime <= 0)
        {
            if (animator != null)
            {
                animator.speed = 1f;
                sr.color = Color.white;
                //speed *= 2f;
            }
        }
        else
            currentIceTime -= Time.deltaTime;

    }

  
    public bool PlayerInSight()
    {
        if (this.IsFreeze() == true) return false;
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerHealth>();

       // Debug.Log(hit.collider);
        return hit.collider != null;
    }

    public void Freeze()
    { 
        if (this.IsFreeze() == true) { currentFreezeTime = freezeTime; return; };
        currentFreezeTime = freezeTime;
        if (animator != null)
            animator.enabled = false;

        //View waterball
        Bounds bounds = GetComponent<Collider2D>().bounds;
        GameObject waterBall = SpawnEffect.instance.SpawnWaterBall(transform.position, bounds);
        waterBall.transform.parent = gameObject.transform;
        Destroy(waterBall, freezeTime);
    }
    public void SlowSpeed()
    {
        currentIceTime = iceTime;
        if (animator != null &&  sr!=null)
        {
            animator.speed = 0.25f;
            sr.color = Color.blue;
            //speed /= 2f;
        }
    }

    protected virtual void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
