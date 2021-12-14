using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject impactEffect;
    public int damage = 20;

    void Update()
    {
       // Debug.Log("Bullet: " + transform.rotation);
        int direction = transform.rotation.y == 0 ? 1 : -1;
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime*direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Effect")) return;
        Instantiate(impactEffect, transform.position, transform.rotation);
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

