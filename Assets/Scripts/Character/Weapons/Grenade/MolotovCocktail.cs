using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovCocktail : MonoBehaviour
{
    public GameObject explosionEffect;
    public int range = 3;
    public int damage;
    public float fireTime;

    private void Awake()
    {
        //rd = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Ground"))
        {
            ///Debug.Log("Boom");
            Explore();
        }
    }


    public void Explore()
    {
        AudioManager.instance.PlayOneShot("Grenade_Molotov");
        Vector3 pos = new Vector3(-range/2*0.5f, 0f, 0);
        //Show Effect 
        for (int i = 0; i < range; i++)
        {
         GameObject fireObject =   Instantiate(explosionEffect, transform.position + pos, transform.rotation);
            Fire fire = fireObject.GetComponent<Fire>();
            if (fire != null) { fire.Damage = damage;
                fire.fireTime = this.fireTime;
            }
            pos.x += 0.5f;
        }
        //Destroy(explosion, 1);
        //Get nearby Object 
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        //// Add Force
        //foreach (Collider2D nearbyObject in colliders)
        //{
        //    //Debug.Log("Grenade Explose " + nearbyObject.name);
        //    Rigidbody2D rigidbody2D = nearbyObject.GetComponent<Rigidbody2D>();
        //    if (rigidbody2D != null)
        //    {
        //        if (rigidbody2D.transform.position.x < transform.position.x)
        //            rigidbody2D.AddForce(new Vector2(-force, force), ForceMode2D.Impulse);
        //        else
        //            rigidbody2D.AddForce(new Vector2(force, force), ForceMode2D.Impulse);
        //    }
        //    EnemyHealth enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
        //    if (enemyHealth != null)
        //    {
        //        enemyHealth.TakeNormalDamage(damage);
        //    }
        //}
        // Damage 
        Destroy(gameObject);
    }
}
