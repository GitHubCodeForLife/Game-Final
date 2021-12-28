using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public bool isDie;

    public Transform damagePoint;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isDie = false;
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.value = (currentHealth * 100 / maxHealth);
    }

    private void TakeDamage(int damage)
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        currentHealth -= damage;
        if (healthBar != null)
            healthBar.value = (currentHealth * 100 / maxHealth);
        if (currentHealth <= 0)
            Die();
    }

    public void TakeNormalDamage(int damage)
    {
       ShowUIDamage(damage);
       TakeDamage(damage);
    }
    public void TakeCritDamage(int damage)
    {
      
        ShowUICritDamage(damage);
        TakeDamage(damage);
    }


    private void ShowUIDamage(int damage)
    {
        //Show damge UI
        float index = Random.Range(1, 100);
        float range = (float)(index * 0.01);
        SpawnEffect.instance.SpawnDamageEffect(transform.position + new Vector3(range, 0), transform.rotation, damage);
    }
    private void ShowUICritDamage(int damage)
    {
        //Show damge UI
        float index = Random.Range(1, 100);
        float range = (float)(index * 0.01);
        SpawnEffect.instance.SpawnDamageCritEffect(transform.position + new Vector3(range, 0), transform.rotation, damage);
    }


    public void Die()
    {
        SpawnEffect.instance.SpawnCoin(transform.position, transform.rotation);
        isDie = true;
        Destroy(gameObject, 0.25f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Enemy Health 1: " + rigidbody.name);
            if (rigidbody != null)
            {
                int direction = transform.rotation.y == 0 ? 1 : -1;
                rigidbody.AddForce(new Vector2(5*direction, 5), ForceMode2D.Impulse);
            }
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Enemy Health 2: " + rigidbody.name);
            if (rigidbody != null)
            {
                int direction = transform.rotation.y == 0 ? 1 : -1;
                rigidbody.AddForce(new Vector2(5 * direction, 5), ForceMode2D.Impulse);
            }
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
