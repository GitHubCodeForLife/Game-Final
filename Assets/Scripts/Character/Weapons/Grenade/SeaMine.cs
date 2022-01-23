using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    public int damage = 100;
    public GameObject explosionEffect;
    public float radius = 5f;
    public LayerMask enemyLayers;
    public float force = 5f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemies"))
            Explore();
    }
    public void Explore()
    {
        //Show Effect 
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1);
        //Get nearby Object 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        // Add Force
        foreach (Collider2D nearbyObject in colliders)
        {
            //Debug.Log("Grenade Explose " + nearbyObject.name);
            Rigidbody2D rigidbody2D = nearbyObject.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                if (rigidbody2D.transform.position.x < transform.position.x)
                    rigidbody2D.AddForce(new Vector2(-force, force), ForceMode2D.Impulse);
                else
                    rigidbody2D.AddForce(new Vector2(force, force), ForceMode2D.Impulse);
            }
            EnemyHealth enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeCritDamage(damage);
            }
        }
        // Damage 
        Destroy(gameObject);
    }
}
