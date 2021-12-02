using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public bool isDie;

    public GameObject damageEffect;
    public Transform damagePoint;
    // Start is called before the first frame update
    void Start()
    {
        isDie = false;
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.value  = (currentHealth * 100 / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {

        //Show damge UI
        float index = Random.Range(1, 100);
        float range = (float)(index * 0.01);
        GameObject gameObject = Instantiate(damageEffect, damagePoint.position+new Vector3(range, 0), damagePoint.rotation);
        gameObject.GetComponent<DamgeUI>().SetDamage(damage);

        if (animator != null)
        {
            //Debug.Log("Trigger Hurt");
            animator.SetTrigger("Hurt");
        }
        currentHealth -= damage;
        if (healthBar != null)
            healthBar.value= (currentHealth * 100 / maxHealth);
        if (currentHealth <= 0)
            Die();
    }
    public void Die()
    {
        isDie = true;
        Destroy(gameObject, 0.25f);
    }
}
