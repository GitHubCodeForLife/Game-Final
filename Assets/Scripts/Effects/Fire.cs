using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public  int Damage = 50;
    private const float damgeMaxTime = 0.1f;
    public float fireTime = 10f;
    private float currentFireTime;
    private float damgeTime = 0.5f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        damgeTime = damgeMaxTime;
        currentFireTime = fireTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireTime <= 0)
        {
            if (animator != null)
                animator.SetTrigger("FireDown");
            Destroy(gameObject, 2f);
            damgeTime = 3f;
        }
        else
            currentFireTime -= Time.deltaTime;
        if (damgeTime > 0)
            damgeTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies")&&damgeTime <= 0)
        {
            Debug.Log("Fire Kill Enemy" + collision.name);
            damgeTime = damgeMaxTime;
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeCritDamage(Damage);
           
        }
        if (collision.CompareTag("Player") && damgeTime <= 0)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(Damage);

        }
    }
}
