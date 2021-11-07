using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isDie;
    // Start is called before the first frame update
    void Start()
    {
        isDie = false;
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.SetMaxHealth(currentHealth * 100 / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (animator != null)
        {
            //Debug.Log("Trigger Hurt");
            animator.SetTrigger("Hurt");
        }
        currentHealth -= damage;
        if (healthBar != null)
            healthBar.SetHealth(currentHealth * 100 / maxHealth);
        if (currentHealth <= 0)
            Die();
    }
    public void Die()
    {
        isDie = true;
        Destroy(gameObject, 0.25f);
    }
}
