using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float health = 100f;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
            Die();

    }
    void Die()
    {
        Debug.Log("Enemey Died");
        //Play animation
        animator.SetBool("IsDead", true);
        //Disable Enemy
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

}
