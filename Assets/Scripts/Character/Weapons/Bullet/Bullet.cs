using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject impactEffect;
    
    public int damage = 20;

    public float timeExist = 5f;
    private void Update()
    {
        timeExist -= Time.deltaTime;
        if (timeExist <= 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet : " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player")) return;
        if (collision.gameObject.CompareTag("Effect")) return;

        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemies"))
        {
            bool isCrit = GameRandom.RandomCriteRate();
            //Random Rate
            //Crit Damage or Not
            if (isCrit)
                collision.gameObject.GetComponent<EnemyHealth>().TakeCritDamage(damage * 2);
            else
                collision.gameObject.GetComponent<EnemyHealth>().TakeNormalDamage(damage);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet : " + collision.gameObject.name);
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Effect")) return;
        Vector2 pos = transform.position;
        Quaternion quaternion = transform.rotation;

        quaternion.y = transform.localScale.x == 1 ? 0 : 180;
       
        GameObject impactObject =  Instantiate(impactEffect, pos,quaternion);
        
        
        Destroy(gameObject);
        if (collision.CompareTag("Enemies"))
        {
            bool isCrit = GameRandom.RandomCriteRate();
            //Random Rate
            //Crit Damage or Not
            if (isCrit)
                collision.GetComponent<EnemyHealth>().TakeCritDamage(damage * 2);
            else
                collision.GetComponent<EnemyHealth>().TakeNormalDamage(damage);
        }
    }

}

