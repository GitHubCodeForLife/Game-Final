using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrenade : MonoBehaviour
{
    public int damage = 50;
    public float delay = 2f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public LayerMask enemyLayers;


    public float force = 5f;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            Explore();
            hasExploded = true;
        }
    }

    public void Explore()
    {
        AudioManager.instance.PlayOneShot("Grenade_Explore");
        Debug.Log("Boom");
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
                enemyHealth.TakeNormalDamage(damage);
            }
        }
        // Damage 
        Destroy(gameObject);
    }
}
